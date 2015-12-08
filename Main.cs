using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XmlToSerialisableClass
{
    public partial class Main : Form
    {
        private XDocument _xmlFile;
        private bool _hasSetManualOutputPath;

        public Main()
        {
            InitializeComponent();

            lblDateFormatSample.Text = String.Format("sample: {0}", DateTime.Now.ToString(txtDateFormat.Text));
            lblDateTimeFormatSample.Text = String.Format("sample: {0}", DateTime.Now.ToString(txtDateTimeFormat.Text));

            txtNamespace.Text = Properties.Settings.Default.NameSpace;

            txtXmlFileLocation.TextChanged += XmlFileChanged;
            txtDateFormat.TextChanged += DateFormatSampleChanged;
            txtDateTimeFormat.TextChanged += DateTimeFormatSampleChanged;

            _hasSetManualOutputPath = false;

        }

        private void BtnXmlFileBrowseClick(object sender, EventArgs e)
        {
            if (xmlOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _xmlFile = XDocument.Load(xmlOpenFileDialog.FileName);
                    txtXmlFileLocation.Text = xmlOpenFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Open XML File Failed:\n" + ex.Message, "Error: File Not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOutputDirectoryBrowse_Click(object sender, EventArgs e)
        {
            if (outputFolderDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputDirectory.Text = outputFolderDialog.SelectedPath;
                _hasSetManualOutputPath = true;
            }
        }

        private void XmlFileChanged(object sender, EventArgs e)
        {
            try
            {
                _xmlFile = XDocument.Load(txtXmlFileLocation.Text);

                if (!_hasSetManualOutputPath)
                {
                    var xmlFileExt = Path.GetExtension(txtXmlFileLocation.Text);
                    if (xmlFileExt != null)
                        txtOutputDirectory.Text = txtXmlFileLocation.Text.Replace(xmlFileExt, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open XML File Failed:\n" + ex.Message, "Error: File Not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DateFormatSampleChanged(object sender, EventArgs e)
        {
            lblDateFormatSample.Text = String.Format("sample: {0}", DateTime.Now.ToString(txtDateFormat.Text));
        }

        private void DateTimeFormatSampleChanged(object sender, EventArgs e)
        {
            lblDateTimeFormatSample.Text = String.Format("sample: {0}", DateTime.Now.ToString(txtDateTimeFormat.Text));
        }

        private void BtnGenerateClick(object sender, EventArgs e)
        {
            if (!File.Exists(txtXmlFileLocation.Text))
            {
                MessageBox.Show("XML file not found", "Error: File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(txtOutputDirectory.Text))
            {
                var response = MessageBox.Show("Output folder does not exist, create it?", "Error: Folder Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (response == DialogResult.Yes)
                    Directory.CreateDirectory(txtOutputDirectory.Text);
                else
                    return;
            }
            if (string.IsNullOrWhiteSpace(txtNamespace.Text))
            {
                MessageBox.Show("Namespace can not be empty", "Error: Namespace not defined", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.NameSpace = txtNamespace.Text;
            Properties.Settings.Default.Save();

            try
            {
                _xmlFile = XDocument.Load(txtXmlFileLocation.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open XML File Failed:\n" + ex.Message, "Error: File Not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            new XmlToCode(_xmlFile.Root, txtNamespace.Text, txtOutputDirectory.Text, txtDateFormat.Text, txtDateTimeFormat.Text);
            MessageBox.Show("Generation Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
