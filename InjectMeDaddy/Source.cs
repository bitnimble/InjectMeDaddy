using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectMeDaddy
{
	public enum SourceType
	{
		JS,
		CSS
	}

	public class Source
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public bool Enabled { get; set; } = true;
		public SourceType Type { get; set; }

		public Source(string name, string desc, string url, SourceType type)
		{
			Name = name;
			Description = desc;
			Url = url;
			Type = type;
		}
	}
}
