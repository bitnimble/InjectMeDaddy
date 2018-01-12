using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InjectMeDaddy
{
	public partial class FormAddSource : Form
	{
		Action<Source> callback = s => { };

		public FormAddSource()
		{
			InitializeComponent();
		}

		public void SetSource(Source source)
		{
			if (source.Type == SourceType.CSS)
				radioBtnCss.Checked = true;
			txtName.Text = source.Name;
			txtUrl.Text = source.Url;
			txtDescription.Text = source.Description;
		}

		public void SetOkCallback(Action<Source> callback)
		{
			this.callback = callback;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			callback(new Source(txtName.Text, txtDescription.Text, txtUrl.Text, radioButtonJs.Checked ? SourceType.JS : SourceType.CSS));
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
