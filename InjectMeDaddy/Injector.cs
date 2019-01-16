using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;
using System.IO.Compression;

namespace InjectMeDaddy
{
	class Injector
	{
		public void Inject(Source[] sources, Action<string> UpdateStatus)
		{
			UpdateStatus("Finding Discord process");
			Process[] discordProcesses = GetDiscordProcess();
			string discordExePath = GetProcessPath(discordProcesses[0].Id);
			string resourcesFolder = Path.Combine(Path.GetDirectoryName(discordExePath), "resources");

			UpdateStatus("Killing Discord");
			try
			{
				foreach (var proc in discordProcesses)
				{
					proc.Kill();
					proc.WaitForExit();
				}
			} catch (Exception ex)
			{

			}

			var appAsar = Path.Combine(resourcesFolder, "app.asar");
			var origAppAsar = Path.Combine(resourcesFolder, "original_app.asar");
			var appFolder = Path.Combine(resourcesFolder, "app");

			//Start with a fresh copy
			if (File.Exists(origAppAsar))
			{
				UpdateStatus("Resetting to vanilla");
				Directory.Delete(appFolder, true);

				if (File.Exists(appAsar))
					File.Delete(origAppAsar);
				else
					File.Move(origAppAsar, appAsar);
			}

			UpdateStatus("Creating injection script");
			var jsSourceList = string.Join(",", sources.Where(s => s.Type == SourceType.JS).Select(s => "\"" + s.Url + "\""));
			var cssSourceList = string.Join(",", sources.Where(s => s.Type == SourceType.CSS).Select(s => "\"" + s.Url + "\""));
			string injector = Properties.Resources.injector;
			injector = injector.Replace("replacejspluginshere", jsSourceList);
			injector = injector.Replace("replacecsspluginshere", cssSourceList);

			UpdateStatus("Processing app.asar");
			ExtractAsar(appAsar, appFolder);
			File.Move(appAsar, origAppAsar);

			if (File.ReadAllText(Path.Combine(appFolder, "package.json")).Contains("app_bootstrap/index.js"))
			{
				string lowerProcName = discordProcesses[0].ProcessName.ToLowerInvariant();
				InjectNew(resourcesFolder, injector, UpdateStatus, lowerProcName.Contains("canary") ? "canary" : lowerProcName.Contains("ptb") ? "ptb" : "" );
			}
			else
			{
				InjectOld(appFolder, injector, UpdateStatus);
			}

			Process.Start(discordExePath);
		}

		void InjectNew(string resourcesFolder, string injector, Action<string> UpdateStatus, string channel)
		{
			string[] parts = resourcesFolder.Split(new[] { "app-" }, StringSplitOptions.None);
			//replace Local with Roaming
			parts[0] = Path.Combine(parts[0].Substring(0, parts[0].LastIndexOf("Local")), "Roaming", "discord" + channel);

			//replace resources with modules
			parts[1] = Path.Combine(parts[1].Substring(0, parts[1].IndexOf("resources")), "modules");

			string discordDesktopCore = Path.Combine(parts[0], parts[1], "discord_desktop_core");
			string coreAsar = Path.Combine(discordDesktopCore, "core.asar");
			string origCoreAsar = coreAsar + ".orig";
			string coreFolder = Path.Combine(discordDesktopCore, "core");

			//Start with a fresh copy
			if (File.Exists(origCoreAsar))
			{
				Directory.Delete(coreFolder, true);

				if (File.Exists(coreAsar))
					File.Delete(origCoreAsar);
				else
					File.Move(origCoreAsar, coreAsar);
			}

			UpdateStatus("Processing core.asar");
			ExtractAsar(coreAsar, coreFolder);
			File.Move(coreAsar, origCoreAsar);

			UpdateStatus("Bypassing CSP");
			var indexFilePreload = Path.Combine(coreFolder, "app", "discord_native", "ipc.js");
			string indexContentsPreload = File.ReadAllText(indexFilePreload);
			indexContentsPreload = indexContentsPreload.Replace("const ipcRenderer = electron.ipcRenderer;", "const ipcRenderer = electron.ipcRenderer; \n\n electron.webFrame.registerURLSchemeAsBypassingCSP('https');");
			File.WriteAllText(indexFilePreload, indexContentsPreload);
			
			UpdateStatus("Injecting script loader");
			var indexFile = Path.Combine(coreFolder, "app", "mainScreen.js");
			string indexContents = File.ReadAllText(indexFile);
			indexContents = indexContents.Replace("loadMainPage();", injector + "\n  loadMainPage();");
			File.WriteAllText(indexFile, indexContents);

			string packageFile = Path.Combine(discordDesktopCore, "index.js");
			string packageContents = File.ReadAllText(packageFile);
			packageContents = packageContents.Replace("./core.asar", "./core");
			File.WriteAllText(packageFile, packageContents);
		}

		void InjectOld(string appFolder, string injector, Action<string> UpdateStatus)
		{
			UpdateStatus("Injecting script loader");
			var indexFile = Path.Combine(appFolder, "index.js");
			string indexContents = File.ReadAllText(indexFile);
			indexContents = indexContents.Replace("mainWindow.webContents.on('dom-ready', function () {});", injector);
			File.WriteAllText(indexFile, indexContents);
		}

		void ExtractAsar(string appAsar, string appFolder)
		{
			Asar asar = new Asar(appAsar);
			asar.Extract(appFolder);
			asar.Dispose();
		}

		Process[] GetDiscordProcess()
		{
			Process[] processes = Process.GetProcesses().Where(p => p.ProcessName.StartsWith("Discord") && !p.ProcessName.EndsWith("Helper")).ToArray();
			if (processes.Length == 0)
				throw new Exception("Could not find Discord executable. Make sure that it is running.");

			//Just pick first for now
			return processes;
		}

		string GetProcessPath(int id)
		{
			var query = "select ExecutablePath from Win32_Process where ProcessId = " + id;
			using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
			using (var collection = searcher.Get())
			{
				string path = collection.Cast<ManagementObject>().Select(mo => mo["ExecutablePath"]).First().ToString();
				return path;
			}
		}
	}
}
