using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace InjectMeDaddy
{
	class Injector
	{
		public void Inject(Source[] sources)
		{
			Process[] discordProcesses = GetDiscordProcess();
			string discordExePath = GetProcessPath(discordProcesses[0].Id);
			string resourcesFolder = Path.Combine(Path.GetDirectoryName(discordExePath), "resources");

			try
			{
				foreach (var proc in discordProcesses)
					proc.Kill();
			} catch (Exception ex)
			{

			}

			var appAsar = Path.Combine(resourcesFolder, "app.asar");
			var origAppAsar = Path.Combine(resourcesFolder, "original_app.asar");
			var appFolder = Path.Combine(resourcesFolder, "app");

			var indexFile = Path.Combine(appFolder, "index.js");

			//Start with a fresh copy
			if (File.Exists(origAppAsar))
			{
				Directory.Delete(appFolder, true);
				File.Move(origAppAsar, appAsar);
			}

			var sourceList = string.Join(",", sources.Select(s => "\"" + s.Url + "\""));
			string injector = Properties.Resources.injector;
			injector = injector.Replace("replacepluginshere", sourceList);

			ExtractAsar(appAsar, appFolder);
			File.Move(appAsar, origAppAsar);

			string indexContents = File.ReadAllText(indexFile);
			indexContents = indexContents.Replace("mainWindow.webContents.on('dom-ready', function () {});", injector);
			File.WriteAllText(indexFile, indexContents);

			Process.Start(discordExePath);
		}

		void ExtractAsar(string appAsar, string appFolder)
		{
			Asar asar = new Asar(appAsar);
			asar.Extract(appFolder);
			asar.Dispose();
		}

		Process[] GetDiscordProcess()
		{
			Process[] processes = Process.GetProcessesByName("Discord");
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
