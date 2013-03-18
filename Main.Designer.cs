namespace XmlToSerialisableClass
{
	partial class Main
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
			this.label1 = new System.Windows.Forms.Label();
			this.xmlOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.txtXmlFileLocation = new System.Windows.Forms.TextBox();
			this.btnXmlFileBrowse = new System.Windows.Forms.Button();
			this.btnOutputDirectoryBrowse = new System.Windows.Forms.Button();
			this.txtOutputDirectory = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNamespace = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDateFormat = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDateTimeFormat = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.outputFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.lblDateFormatSample = new System.Windows.Forms.Label();
			this.lblDateTimeFormatSample = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(77, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "XML File";
			// 
			// xmlOpenFileDialog
			// 
			this.xmlOpenFileDialog.Filter = "XML files|*.xml|All files|*.*";
			// 
			// txtXmlFileLocation
			// 
			this.txtXmlFileLocation.AllowDrop = true;
			this.txtXmlFileLocation.Location = new System.Drawing.Point(131, 49);
			this.txtXmlFileLocation.Name = "txtXmlFileLocation";
			this.txtXmlFileLocation.Size = new System.Drawing.Size(196, 20);
			this.txtXmlFileLocation.TabIndex = 1;
			this.txtXmlFileLocation.WordWrap = false;
			// 
			// btnXmlFileBrowse
			// 
			this.btnXmlFileBrowse.Location = new System.Drawing.Point(327, 47);
			this.btnXmlFileBrowse.Name = "btnXmlFileBrowse";
			this.btnXmlFileBrowse.Size = new System.Drawing.Size(64, 23);
			this.btnXmlFileBrowse.TabIndex = 2;
			this.btnXmlFileBrowse.Text = "Browse";
			this.btnXmlFileBrowse.UseVisualStyleBackColor = true;
			this.btnXmlFileBrowse.Click += new System.EventHandler(this.BtnXmlFileBrowseClick);
			// 
			// btnOutputDirectoryBrowse
			// 
			this.btnOutputDirectoryBrowse.Location = new System.Drawing.Point(327, 242);
			this.btnOutputDirectoryBrowse.Name = "btnOutputDirectoryBrowse";
			this.btnOutputDirectoryBrowse.Size = new System.Drawing.Size(64, 23);
			this.btnOutputDirectoryBrowse.TabIndex = 5;
			this.btnOutputDirectoryBrowse.Text = "Browse";
			this.btnOutputDirectoryBrowse.UseVisualStyleBackColor = true;
			this.btnOutputDirectoryBrowse.Click += new System.EventHandler(this.btnOutputDirectoryBrowse_Click);
			// 
			// txtOutputDirectory
			// 
			this.txtOutputDirectory.Location = new System.Drawing.Point(131, 244);
			this.txtOutputDirectory.Name = "txtOutputDirectory";
			this.txtOutputDirectory.Size = new System.Drawing.Size(196, 20);
			this.txtOutputDirectory.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(43, 247);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Output Directory";
			// 
			// txtNamespace
			// 
			this.txtNamespace.Location = new System.Drawing.Point(131, 95);
			this.txtNamespace.Name = "txtNamespace";
			this.txtNamespace.Size = new System.Drawing.Size(260, 20);
			this.txtNamespace.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(61, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Namespace";
			// 
			// txtDateFormat
			// 
			this.txtDateFormat.Location = new System.Drawing.Point(131, 121);
			this.txtDateFormat.Name = "txtDateFormat";
			this.txtDateFormat.Size = new System.Drawing.Size(141, 20);
			this.txtDateFormat.TabIndex = 9;
			this.txtDateFormat.Text = "yyyy-MM-dd";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(60, 124);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Date Format";
			// 
			// txtDateTimeFormat
			// 
			this.txtDateTimeFormat.Location = new System.Drawing.Point(131, 166);
			this.txtDateTimeFormat.Name = "txtDateTimeFormat";
			this.txtDateTimeFormat.Size = new System.Drawing.Size(141, 20);
			this.txtDateTimeFormat.TabIndex = 11;
			this.txtDateTimeFormat.Text = "yyyy-MM-ddTH:mm:ss";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(37, 169);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "DateTime Format";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(263, 287);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 23);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(327, 287);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(64, 23);
			this.btnGenerate.TabIndex = 13;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.BtnGenerateClick);
			// 
			// lblDateFormatSample
			// 
			this.lblDateFormatSample.AutoSize = true;
			this.lblDateFormatSample.Location = new System.Drawing.Point(128, 144);
			this.lblDateFormatSample.Name = "lblDateFormatSample";
			this.lblDateFormatSample.Size = new System.Drawing.Size(46, 13);
			this.lblDateFormatSample.TabIndex = 14;
			this.lblDateFormatSample.Text = "sample: ";
			// 
			// lblDateTimeFormatSample
			// 
			this.lblDateTimeFormatSample.AutoSize = true;
			this.lblDateTimeFormatSample.Location = new System.Drawing.Point(128, 189);
			this.lblDateTimeFormatSample.Name = "lblDateTimeFormatSample";
			this.lblDateTimeFormatSample.Size = new System.Drawing.Size(46, 13);
			this.lblDateTimeFormatSample.TabIndex = 15;
			this.lblDateTimeFormatSample.Text = "sample: ";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(425, 335);
			this.Controls.Add(this.lblDateTimeFormatSample);
			this.Controls.Add(this.lblDateFormatSample);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtDateTimeFormat);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtDateFormat);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtNamespace);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnOutputDirectoryBrowse);
			this.Controls.Add(this.txtOutputDirectory);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnXmlFileBrowse);
			this.Controls.Add(this.txtXmlFileLocation);
			this.Controls.Add(this.label1);
			this.Name = "Main";
			this.Text = "Xml To Serialisable c# Classes";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog xmlOpenFileDialog;
		private System.Windows.Forms.TextBox txtXmlFileLocation;
		private System.Windows.Forms.Button btnXmlFileBrowse;
		private System.Windows.Forms.Button btnOutputDirectoryBrowse;
		private System.Windows.Forms.TextBox txtOutputDirectory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNamespace;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDateFormat;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDateTimeFormat;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.FolderBrowserDialog outputFolderDialog;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label lblDateFormatSample;
		private System.Windows.Forms.Label lblDateTimeFormatSample;
	}
}

