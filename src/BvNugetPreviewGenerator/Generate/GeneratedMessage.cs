using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BvNugetPreviewGenerator.Generate
{
    public partial class GeneratedMessage: Form
    {

        private const int Height_ExpectedFailure = 157;
        private const int Height_UnexpectedFailure = 386;
        private const int Height_Success = 271;

        public GeneratedMessage()
        {
            InitializeComponent();
        }

        private PreviewPackageGenerateResult _PreviewPackageGenerateResult;
        public PreviewPackageGenerateResult PreviewPackageGenerateResult
        {
            get => _PreviewPackageGenerateResult;
            set
            {
                _PreviewPackageGenerateResult = value;
                SetControls();
            }
        }

        public void SetControls()
        {
            var result = _PreviewPackageGenerateResult;
            if (result == null)
                return;

            if (result.IsSuccess)
            {
                lblHeading.Text = "Nuget Preview Package Created Successfully";
                picMainIcon.Image = SystemIcons.Information.ToBitmap();
                txtExceptionDetails.Visible = false;
                lblExceptionDetails.Visible = false;
                Height = Height_Success;
            }
            else if (result.IsExpectedFailure)
            {
                lblHeading.Text = "Unable to Create Nuget Preview Package";
                picMainIcon.Image = SystemIcons.Warning.ToBitmap();
                txtExceptionDetails.Visible = false;
                lblExceptionDetails.Visible = false;
                txtLogOutput.Visible = false;
                lblLogOutput.Visible = false;
                Height = Height_ExpectedFailure;
            }
            else
            {
                lblHeading.Text = "Nuget Package Creation Encounted an Unexpected Error";
                picMainIcon.Image = SystemIcons.Error.ToBitmap();
                txtExceptionDetails.Visible = true;
                lblExceptionDetails.Visible = true;
                Height = Height_UnexpectedFailure;
            }

            lblMainText.Text = result.Message;
            txtLogOutput.Text = result.LogText;

            if (!result.IsSuccess && result.Exception != null)
            {
                var ex = result.Exception;
                txtExceptionDetails.Text = $"{ex.Message}\r\n\r\n" +
                                            "Stack Trace\r\n" +
                                            "-----------\r\n" +
                                            $"{ex.StackTrace}";


            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
