using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectMeDaddy
{
	class Asar : IDisposable
	{
		string path;
		BinaryReader reader;
		IDictionary<string, object> header;
		int baseOffset;

		public Asar(string path)
		{
			BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
			uint dataSize = reader.ReadUInt32();
			uint headerSize = reader.ReadUInt32();
			uint headerObjectSize = reader.ReadUInt32();
			uint headerStringSize = reader.ReadUInt32();

			string headerJson = Encoding.UTF8.GetString(reader.ReadBytes((int)headerStringSize));

			this.path = path;
			this.reader = reader;
			this.header = JsonConvert.DeserializeObject<IDictionary<string, object>>(headerJson, new JsonConverter[] { new DictionaryConverter() });
			this.baseOffset = RoundUp(16 + (int)headerStringSize, 4);
		}

		public void Extract(string outputPath)
		{
			ExtractDirectory(".", header["files"] as IDictionary<string, object>, outputPath);
		}

		private void CopyUnpackedFile(string source, string destination)
		{
			string unpackedDir = path + ".unpacked";
			if (!Directory.Exists(unpackedDir))
			{
				//Unpacked dir doesn't exist
				return;
			}

			var src = Path.Combine(unpackedDir, source);
			if (!File.Exists(src))
			{
				//File doesn't exist
				return;
			}

			var dest = Path.Combine(destination, source);
			File.Copy(src, dest);
		}

		private void ExtractFile(string source, IDictionary<string, object> info, string destination)
		{
			if (!info.ContainsKey("offset"))
			{
				CopyUnpackedFile(source, destination);
				return;
			}

			reader.BaseStream.Seek(baseOffset + long.Parse(info["offset"].ToString()), SeekOrigin.Begin);
			byte[] buffer = reader.ReadBytes(int.Parse(info["size"].ToString()));

			var dest = Path.Combine(destination, source);
			File.WriteAllBytes(dest, buffer);
		}

		private void ExtractDirectory(string source, IDictionary<string, object> files, string destination)
		{
			string dest = Path.Combine(destination, source);

			if (!Directory.Exists(dest))
				Directory.CreateDirectory(dest);

			foreach (var kvp in files)
			{
				var path = Path.Combine(source, kvp.Key);
				var info = kvp.Value as IDictionary<string, object>;

				if (info.ContainsKey("files"))
				{
					ExtractDirectory(path, info["files"] as IDictionary<string, object>, destination);
				}
				else
				{
					ExtractFile(path, info, destination);
				}
			}
		}

		private int RoundUp(int i, int m)
		{
			return (i + m - 1) & ~(m - 1);
		}

		public void Dispose()
		{
			reader.Close();
		}
	}
}
