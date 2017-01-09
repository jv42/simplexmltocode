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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSetup = new System.Windows.Forms.TabPage();
            this.tabPageRun = new System.Windows.Forms.TabPage();
            this.xmlOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblDateTimeFormatSample = new System.Windows.Forms.Label();
            this.outputFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblDateFormatSample = new System.Windows.Forms.Label();
            this.txtDateTimeFormat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateFormat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOutputDirectoryBrowse = new System.Windows.Forms.Button();
            this.txtOutputDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXmlFileBrowse = new System.Windows.Forms.Button();
            this.txtXmlFileLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageSetup.SuspendLayout();
            this.tabPageRun.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSetup);
            this.tabControl1.Controls.Add(this.tabPageRun);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(425, 335);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPageSetup
            // 
            this.tabPageSetup.Controls.Add(this.lblDateTimeFormatSample);
            this.tabPageSetup.Controls.Add(this.lblDateFormatSample);
            this.tabPageSetup.Controls.Add(this.txtDateTimeFormat);
            this.tabPageSetup.Controls.Add(this.label5);
            this.tabPageSetup.Controls.Add(this.txtDateFormat);
            this.tabPageSetup.Controls.Add(this.label4);
            this.tabPageSetup.Controls.Add(this.txtNamespace);
            this.tabPageSetup.Controls.Add(this.label3);
            this.tabPageSetup.Controls.Add(this.btnOutputDirectoryBrowse);
            this.tabPageSetup.Controls.Add(this.txtOutputDirectory);
            this.tabPageSetup.Controls.Add(this.label2);
            this.tabPageSetup.Controls.Add(this.btnXmlFileBrowse);
            this.tabPageSetup.Controls.Add(this.txtXmlFileLocation);
            this.tabPageSetup.Controls.Add(this.label1);
            this.tabPageSetup.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetup.Name = "tabPageSetup";
            this.tabPageSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetup.Size = new System.Drawing.Size(417, 309);
            this.tabPageSetup.TabIndex = 0;
            this.tabPageSetup.Text = "Setup";
            this.tabPageSetup.UseVisualStyleBackColor = true;
            // 
            // tabPageRun
            // 
            this.tabPageRun.Controls.Add(this.textBoxOutput);
            this.tabPageRun.Controls.Add(this.btnGenerate);
            this.tabPageRun.Controls.Add(this.btnCancel);
            this.tabPageRun.Location = new System.Drawing.Point(4, 22);
            this.tabPageRun.Name = "tabPageRun";
            this.tabPageRun.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRun.Size = new System.Drawing.Size(417, 309);
            this.tabPageRun.TabIndex = 1;
            this.tabPageRun.Text = "Run";
            this.tabPageRun.UseVisualStyleBackColor = true;
            // 
            // xmlOpenFileDialog
            // 
            this.xmlOpenFileDialog.Filter = "XML files|*.xml|All files|*.*";
            // 
            // lblDateTimeFormatSample
            // 
            this.lblDateTimeFormatSample.AutoSize = true;
            this.lblDateTimeFormatSample.Location = new System.Drawing.Point(122, 165);
            this.lblDateTimeFormatSample.Name = "lblDateTimeFormatSample";
            this.lblDateTimeFormatSample.Size = new System.Drawing.Size(46, 13);
            this.lblDateTimeFormatSample.TabIndex = 31;
            this.lblDateTimeFormatSample.Text = "sample: ";
            // 
            // lblDateFormatSample
            // 
            this.lblDateFormatSample.AutoSize = true;
            this.lblDateFormatSample.Location = new System.Drawing.Point(122, 120);
            this.lblDateFormatSample.Name = "lblDateFormatSample";
            this.lblDateFormatSample.Size = new System.Drawing.Size(46, 13);
            this.lblDateFormatSample.TabIndex = 30;
            this.lblDateFormatSample.Text = "sample: ";
            // 
            // txtDateTimeFormat
            // 
            this.txtDateTimeFormat.Location = new System.Drawing.Point(125, 142);
            this.txtDateTimeFormat.Name = "txtDateTimeFormat";
            this.txtDateTimeFormat.Size = new System.Drawing.Size(141, 20);
            this.txtDateTimeFormat.TabIndex = 27;
            this.txtDateTimeFormat.Text = "yyyy-MM-ddTH:mm:ss";
            this.txtDateTimeFormat.TextChanged += new System.EventHandler(this.DateTimeFormatSampleChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "DateTime Format";
            // 
            // txtDateFormat
            // 
            this.txtDateFormat.Location = new System.Drawing.Point(125, 97);
            this.txtDateFormat.Name = "txtDateFormat";
            this.txtDateFormat.Size = new System.Drawing.Size(141, 20);
            this.txtDateFormat.TabIndex = 25;
            this.txtDateFormat.Text = "yyyy-MM-dd";
            this.txtDateFormat.TextChanged += new System.EventHandler(this.DateFormatSampleChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Date Format";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(125, 71);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(260, 20);
            this.txtNamespace.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Namespace";
            // 
            // btnOutputDirectoryBrowse
            // 
            this.btnOutputDirectoryBrowse.Location = new System.Drawing.Point(321, 218);
            this.btnOutputDirectoryBrowse.Name = "btnOutputDirectoryBrowse";
            this.btnOutputDirectoryBrowse.Size = new System.Drawing.Size(64, 23);
            this.btnOutputDirectoryBrowse.TabIndex = 21;
            this.btnOutputDirectoryBrowse.Text = "Browse";
            this.btnOutputDirectoryBrowse.UseVisualStyleBackColor = true;
            this.btnOutputDirectoryBrowse.Click += new System.EventHandler(this.btnOutputDirectoryBrowse_Click);
            // 
            // txtOutputDirectory
            // 
            this.txtOutputDirectory.Location = new System.Drawing.Point(125, 220);
            this.txtOutputDirectory.Name = "txtOutputDirectory";
            this.txtOutputDirectory.Size = new System.Drawing.Size(196, 20);
            this.txtOutputDirectory.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Output Directory";
            // 
            // btnXmlFileBrowse
            // 
            this.btnXmlFileBrowse.Location = new System.Drawing.Point(321, 23);
            this.btnXmlFileBrowse.Name = "btnXmlFileBrowse";
            this.btnXmlFileBrowse.Size = new System.Drawing.Size(64, 23);
            this.btnXmlFileBrowse.TabIndex = 18;
            this.btnXmlFileBrowse.Text = "Browse";
            this.btnXmlFileBrowse.UseVisualStyleBackColor = true;
            this.btnXmlFileBrowse.Click += new System.EventHandler(this.BtnXmlFileBrowseClick);
            // 
            // txtXmlFileLocation
            // 
            this.txtXmlFileLocation.AllowDrop = true;
            this.txtXmlFileLocation.Location = new System.Drawing.Point(125, 25);
            this.txtXmlFileLocation.Name = "txtXmlFileLocation";
            this.txtXmlFileLocation.Size = new System.Drawing.Size(196, 20);
            this.txtXmlFileLocation.TabIndex = 17;
            this.txtXmlFileLocation.WordWrap = false;
            this.txtXmlFileLocation.TextChanged += new System.EventHandler(this.XmlFileChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "XML File";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(8, 6);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(64, 23);
            this.btnGenerate.TabIndex = 31;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerateClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(78, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxOutput.Location = new System.Drawing.Point(3, 35);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(411, 271);
            this.textBoxOutput.TabIndex = 32;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 335);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "XML To Serializable C# Classes";
            this.tabControl1.ResumeLayout(false);
            this.tabPageSetup.ResumeLayout(false);
            this.tabPageSetup.PerformLayout();
            this.tabPageRun.ResumeLayout(false);
            this.tabPageRun.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSetup;
        private System.Windows.Forms.Label lblDateTimeFormatSample;
        private System.Windows.Forms.Label lblDateFormatSample;
        private System.Windows.Forms.TextBox txtDateTimeFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDateFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOutputDirectoryBrowse;
        private System.Windows.Forms.TextBox txtOutputDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXmlFileBrowse;
        private System.Windows.Forms.TextBox txtXmlFileLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageRun;
        private System.Windows.Forms.OpenFileDialog xmlOpenFileDialog;
        private System.Windows.Forms.FolderBrowserDialog outputFolderDialog;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textBoxOutput;
    }
}

