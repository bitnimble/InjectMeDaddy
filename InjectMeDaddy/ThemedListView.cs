using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace InjectMeDaddy
{
	public class ThemedListView : ListView
	{
		private bool IgnoreNextCheck = false;

		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
		public static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

		public ThemedListView()
			: base()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			SetWindowTheme(this.Handle, "explorer", null);
		}

		protected override void OnItemCheck(ItemCheckEventArgs ice)
		{
			if (IgnoreNextCheck)
			{
				ice.NewValue = ice.CurrentValue;
				IgnoreNextCheck = false;
			}
			else
			{
				base.OnItemCheck(ice);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.Clicks > 1)
				IgnoreNextCheck = true;
			base.OnMouseDown(e);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			IgnoreNextCheck = false;
			base.OnKeyDown(e);
		}
	}
}
