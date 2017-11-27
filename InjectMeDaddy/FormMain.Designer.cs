namespace InjectMeDaddy
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listSources = new InjectMeDaddy.ThemedListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnAddSource = new System.Windows.Forms.Button();
			this.btnInject = new System.Windows.Forms.Button();
			this.btnSaveSourceList = new System.Windows.Forms.Button();
			this.btnLoadSourceList = new System.Windows.Forms.Button();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusSpacer = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// listSources
			// 
			this.listSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listSources.CheckBoxes = true;
			this.listSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colDescription,
            this.colUrl});
			this.listSources.FullRowSelect = true;
			this.listSources.Location = new System.Drawing.Point(12, 12);
			this.listSources.Name = "listSources";
			this.listSources.Size = new System.Drawing.Size(706, 297);
			this.listSources.TabIndex = 0;
			this.listSources.UseCompatibleStateImageBehavior = false;
			this.listSources.View = System.Windows.Forms.View.Details;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 100;
			// 
			// colType
			// 
			this.colType.DisplayIndex = 1;
			this.colType.Text = "Type";
			this.colType.Width = 60;
			// 
			// colDescription
			// 
			this.colDescription.DisplayIndex = 2;
			this.colDescription.Text = "Description";
			this.colDescription.Width = 200;
			// 
			// colUrl
			// 
			this.colUrl.DisplayIndex = 3;
			this.colUrl.Text = "Url";
			this.colUrl.Width = 402;
			// 
			// btnAddSource
			// 
			this.btnAddSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddSource.Location = new System.Drawing.Point(12, 315);
			this.btnAddSource.Name = "btnAddSource";
			this.btnAddSource.Size = new System.Drawing.Size(75, 23);
			this.btnAddSource.TabIndex = 1;
			this.btnAddSource.Text = "Add source";
			this.btnAddSource.UseVisualStyleBackColor = true;
			this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
			// 
			// btnInject
			// 
			this.btnInject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInject.Location = new System.Drawing.Point(643, 315);
			this.btnInject.Name = "btnInject";
			this.btnInject.Size = new System.Drawing.Size(75, 23);
			this.btnInject.TabIndex = 2;
			this.btnInject.Text = "Inject";
			this.btnInject.UseVisualStyleBackColor = true;
			this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
			// 
			// btnSaveSourceList
			// 
			this.btnSaveSourceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSaveSourceList.Location = new System.Drawing.Point(93, 315);
			this.btnSaveSourceList.Name = "btnSaveSourceList";
			this.btnSaveSourceList.Size = new System.Drawing.Size(90, 23);
			this.btnSaveSourceList.TabIndex = 3;
			this.btnSaveSourceList.Text = "Save source list";
			this.btnSaveSourceList.UseVisualStyleBackColor = true;
			this.btnSaveSourceList.Click += new System.EventHandler(this.btnSaveSourceList_Click);
			// 
			// btnLoadSourceList
			// 
			this.btnLoadSourceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnLoadSourceList.Location = new System.Drawing.Point(189, 315);
			this.btnLoadSourceList.Name = "btnLoadSourceList";
			this.btnLoadSourceList.Size = new System.Drawing.Size(90, 23);
			this.btnLoadSourceList.TabIndex = 4;
			this.btnLoadSourceList.Text = "Load source list";
			this.btnLoadSourceList.UseVisualStyleBackColor = true;
			this.btnLoadSourceList.Click += new System.EventHandler(this.btnLoadSourceList_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusSpacer,
            this.statusProgressBar});
			this.statusStrip.Location = new System.Drawing.Point(0, 341);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(730, 22);
			this.statusStrip.TabIndex = 5;
			this.statusStrip.Text = "statusStrip1";
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// statusSpacer
			// 
			this.statusSpacer.Name = "statusSpacer";
			this.statusSpacer.Size = new System.Drawing.Size(613, 17);
			this.statusSpacer.Spring = true;
			// 
			// statusProgressBar
			// 
			this.statusProgressBar.Enabled = false;
			this.statusProgressBar.MarqueeAnimationSpeed = 0;
			this.statusProgressBar.Name = "statusProgressBar";
			this.statusProgressBar.Size = new System.Drawing.Size(100, 16);
			this.statusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(730, 363);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.btnLoadSourceList);
			this.Controls.Add(this.btnSaveSourceList);
			this.Controls.Add(this.btnInject);
			this.Controls.Add(this.btnAddSource);
			this.Controls.Add(this.listSources);
			this.Name = "FormMain";
			this.Text = "InjectMeDaddy";
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ThemedListView listSources;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.ColumnHeader colUrl;
		private System.Windows.Forms.Button btnAddSource;
		private System.Windows.Forms.Button btnInject;
		private System.Windows.Forms.Button btnSaveSourceList;
		private System.Windows.Forms.Button btnLoadSourceList;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel statusSpacer;
		private System.Windows.Forms.ColumnHeader colType;
	}
}

