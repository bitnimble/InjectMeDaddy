using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Collections;

namespace InjectMeDaddy
{
	public partial class FormMain : Form
	{
		List<Source> sources = new List<Source>();

		public FormMain()
		{
			InitializeComponent();
			listSources.DoubleClick += ListSources_DoubleClick;
			listSources.ItemChecked += ListSources_ItemChecked;
		}

		private void ListSources_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			((Source)e.Item.Tag).Enabled = e.Item.Checked;
		}

		private void ListSources_DoubleClick(object sender, EventArgs e)
		{
			if (listSources.SelectedItems.Count == 0)
				return;

			ListViewItem selectedItem = listSources.SelectedItems[0];
			Source source = (Source)selectedItem.Tag;

			FormAddSource editSource = new FormAddSource();
			editSource.SetSource(source);
			editSource.SetOkCallback(s =>
			{
				selectedItem.SubItems[0].Text = s.Name;
				selectedItem.SubItems[1].Text = s.Description;
				selectedItem.SubItems[2].Text = s.Url;
				sources.Remove(source);
				sources.Add(s);
			});
			editSource.ShowDialog();
		}

		private void btnAddSource_Click(object sender, EventArgs e)
		{
			FormAddSource addSource = new FormAddSource();
			addSource.SetOkCallback(source =>
			{
				ListViewItem item = new ListViewItem(new string[] { source.Name, source.Description, source.Url });
				item.Tag = source;
				item.Checked = true;
				listSources.Items.Add(item);
				sources.Add(source);
			});
			addSource.ShowDialog();
		}

		private void btnSaveSourceList_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "json files (*.json)|*.json";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				string json = JsonConvert.SerializeObject(sources);
				File.WriteAllText(dlg.FileName, json);
			}
		}

		private void btnLoadSourceList_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "json files (*.json)|*.json";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				string json = File.ReadAllText(dlg.FileName);
				Source[] sourceArray;
				try
				{
					sourceArray = JsonConvert.DeserializeObject<Source[]>(json);
					sources = new List<Source>(sourceArray);
					listSources.SuspendLayout();
					listSources.Items.Clear();
					foreach (var source in sources)
					{
						ListViewItem item = new ListViewItem(new string[] { source.Name, source.Description, source.Url });
						item.Tag = source;
						item.Checked = source.Enabled;
						listSources.Items.Add(item);
					}
					listSources.ResumeLayout();
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occurred when attempting to load the specified source list.", "Load error");
				}
			}
		}
		
		private void btnInject_Click(object sender, EventArgs e)
		{
			Injector injector = new Injector();
			try
			{
				injector.Inject(sources.Where(s => s.Enabled).ToArray());
				MessageBox.Show("Done!");
			} catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
