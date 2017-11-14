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
            this.colDescription,
            this.colUrl});
			this.listSources.FullRowSelect = true;
			this.listSources.Location = new System.Drawing.Point(12, 12);
			this.listSources.Name = "listSources";
			this.listSources.Size = new System.Drawing.Size(526, 281);
			this.listSources.TabIndex = 0;
			this.listSources.UseCompatibleStateImageBehavior = false;
			this.listSources.View = System.Windows.Forms.View.Details;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 100;
			// 
			// colDescription
			// 
			this.colDescription.Text = "Description";
			this.colDescription.Width = 144;
			// 
			// colUrl
			// 
			this.colUrl.Text = "Url";
			this.colUrl.Width = 300;
			// 
			// btnAddSource
			// 
			this.btnAddSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddSource.Location = new System.Drawing.Point(12, 299);
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
			this.btnInject.Location = new System.Drawing.Point(463, 299);
			this.btnInject.Name = "btnInject";
			this.btnInject.Size = new System.Drawing.Size(75, 23);
			this.btnInject.TabIndex = 2;
			this.btnInject.Text = "Inject";
			this.btnInject.UseVisualStyleBackColor = true;
			this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
			// 
			// btnSaveSourceList
			// 
			this.btnSaveSourceList.Location = new System.Drawing.Point(93, 299);
			this.btnSaveSourceList.Name = "btnSaveSourceList";
			this.btnSaveSourceList.Size = new System.Drawing.Size(90, 23);
			this.btnSaveSourceList.TabIndex = 3;
			this.btnSaveSourceList.Text = "Save source list";
			this.btnSaveSourceList.UseVisualStyleBackColor = true;
			this.btnSaveSourceList.Click += new System.EventHandler(this.btnSaveSourceList_Click);
			// 
			// btnLoadSourceList
			// 
			this.btnLoadSourceList.Location = new System.Drawing.Point(189, 299);
			this.btnLoadSourceList.Name = "btnLoadSourceList";
			this.btnLoadSourceList.Size = new System.Drawing.Size(90, 23);
			this.btnLoadSourceList.TabIndex = 4;
			this.btnLoadSourceList.Text = "Load source list";
			this.btnLoadSourceList.UseVisualStyleBackColor = true;
			this.btnLoadSourceList.Click += new System.EventHandler(this.btnLoadSourceList_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 332);
			this.Controls.Add(this.btnLoadSourceList);
			this.Controls.Add(this.btnSaveSourceList);
			this.Controls.Add(this.btnInject);
			this.Controls.Add(this.btnAddSource);
			this.Controls.Add(this.listSources);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "FormMain";
			this.Text = "InjectMeDaddy ( ͡° ͜ʖ ͡°) ";
			this.ResumeLayout(false);

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
	}
}

