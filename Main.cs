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

            var classTemplate = File.ReadAllText("ClassTemplateWithRegions.txt");

            var converter = new XmlToCode(_xmlFile.Root, txtNamespace.Text, txtOutputDirectory.Text, txtDateFormat.Text, txtDateTimeFormat.Text, classTemplate, (log) => AddLineToOutputBox(log));

            converter.ConvertAsync().ContinueWith((task) =>
            {
                if (task.IsFaulted)
                    MessageBox.Show("Error during generation: " + task.Exception?.GetInnermost()?.Message ?? "unknown error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Generation Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            );
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Log management

        private void AddLineToOutputBox(string line)
        {
            if (textBoxOutput.InvokeRequired)
            {
                this.Invoke(() => DoAddLine(line));
            }
            else
            {
                DoAddLine(line);
            }
        }

        private void DoAddLine(string line)
        {
            textBoxOutput.AppendText(line);
            textBoxOutput.AppendText(Environment.NewLine);
        }

        #endregion
    }

    /// <summary>
    /// Provide extension methods dealing with System.Windows.Forms.Control.
    /// </summary>
    public static class ControlExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            control.Invoke(action);
        }
    }

    /// <summary>
    /// Provide extension methods dealing with System.Exception.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets the innermost exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static Exception GetInnermost(this Exception ex)
        {
            if (ex.InnerException == null)
                return ex;

            return GetInnermost(ex.InnerException);
        }
    }
}
