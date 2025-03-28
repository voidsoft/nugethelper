using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BvNugetPreviewGenerator.Generate
{
    public partial class GenerateForm: Form
    {

        //private const int Height_ExpectedFailure = 157;
        //private const int Height_UnexpectedFailure = 386;
        //private const int Height_Success = 271;

        public GenerateForm()
        {
            InitializeComponent();
        }

        private PreviewPackageGenerateResult _PreviewPackageGenerateResult;
        public void SetResult(PreviewPackageGenerateResult result)
        {
            _PreviewPackageGenerateResult = result;
            SetControls();
        }

        public void StartProgress()
        {
            _PreviewPackageGenerateResult = null;
            prgProgress.Value = 0;
            SetControls();
            Application.DoEvents();
        }
        public void SetProgress(int progress, string message)
        {
            prgProgress.Value = progress;
            lblProgressUpdate.Text = message;
            Application.DoEvents();
        }

        public void LogEvent(string message)
        {
            txtLogOutput.Text += message + Environment.NewLine;
            txtLogOutput.SelectionStart = txtLogOutput.Text.Length;
            txtLogOutput.ScrollToCaret();
            Application.DoEvents();
        }

        public void SetControls()
        {
            var result = _PreviewPackageGenerateResult;
            if (result == null)
            {
                picMainIcon.Image = Properties.Resources.windowicon32;
                lblHeading.Text = "Nuget Preview Package is being Created";
                lblMainText.Text = "The preview package is being created, this may take a few minutes.";
                btnOk.Enabled = false;
                return;
            }

            btnOk.Enabled = true;



            if (result.IsSuccess)
            {
                lblHeading.Text = "Nuget Preview Package Created Successfully";
            }
            else if (result.IsExpectedFailure)
            {
                lblHeading.Text = "Unable to Create Nuget Preview Package";
                picMainIcon.Image = SystemIcons.Warning.ToBitmap();
              
            }
            else
            {
                lblHeading.Text = "Nuget Package Creation Encounted an Unexpected Error";
                picMainIcon.Image = SystemIcons.Error.ToBitmap();
            }

            lblMainText.Text = result.Message;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GenerateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
