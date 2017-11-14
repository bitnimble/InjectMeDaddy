using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace InjectMeDaddy
{
	public class GhostTextbox : TextBox
	{
		[DllImport("user32.dll", EntryPoint = "SendMessageW")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

		private string ghostText;
		public string GhostText
		{
			get { return ghostText; }
			set { ghostText = value; updateGhostText(); }
		}

		public GhostTextbox() : base()
		{

		}

		public GhostTextbox(string ghostText) : this()
		{
			GhostText = ghostText;
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			updateGhostText();
		}

		private void updateGhostText()
		{
			if (!this.IsHandleCreated || string.IsNullOrWhiteSpace(ghostText))
				return;

			IntPtr mem = Marshal.StringToHGlobalUni(ghostText);
			SendMessage(this.Handle, 0x1501, (IntPtr)1, mem);
			Marshal.FreeHGlobal(mem);
		}
	}
}
