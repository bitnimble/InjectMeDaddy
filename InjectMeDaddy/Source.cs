using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectMeDaddy
{
	public class Source
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public bool Enabled { get; set; } = true;

		public Source(string name, string desc, string url)
		{
			Name = name;
			Description = desc;
			Url = url;
		}
	}
}
