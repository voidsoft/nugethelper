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

        public string ProjectPath { get; set; }
        public string NugetPath { get; set; }

        private IPackageGenerator _Generator;
        private PackageGenerateResult _PreviewPackageGenerateResult;

        public GenerateForm(IPackageGenerator generator)
        {
            InitializeComponent();
            _Generator = generator;
            generator.ProgressEvent += Generator_ProgressEvent;
            generator.LogEvent += Generator_LogEvent;
            generator.CompleteEvent += Generator_CompleteEvent;
        }

        
        private void SetResult(PackageGenerateResult result)
        {
            _PreviewPackageGenerateResult = result;
            SetControls();
        }

        private void StartProgress()
        {
            _PreviewPackageGenerateResult = null;
            prgProgress.Value = 0;
            SetControls();
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



            if (result.ResultType == PreviewPackageGenerateResultType.Success)
            {
                lblHeading.Text = "Nuget Preview Package Created Successfully";
            }
            else if (result.ResultType == PreviewPackageGenerateResultType.ExpectedFailure)
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

        private void GenerateForm_Shown(object sender, EventArgs e)
        {
            StartProgress();            
            _Generator.GeneratePackage(ProjectPath, NugetPath);
        }

        private void Generator_CompleteEvent(PackageGenerateResult obj)
        {
            SetResult(obj);
        }

        private void Generator_LogEvent(string message)
        {
            txtLogOutput.Text += message + Environment.NewLine;
            txtLogOutput.SelectionStart = txtLogOutput.Text.Length;
            txtLogOutput.ScrollToCaret();
            Application.DoEvents();
        }

        private void Generator_ProgressEvent(int progress, string message)
        {
            prgProgress.Value = progress;
            lblProgressUpdate.Text = message;
            Application.DoEvents();
        }
    }
}
