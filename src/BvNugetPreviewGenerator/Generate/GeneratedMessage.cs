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
                picMainIcon.Image = SystemIcons.Information.ToBitmap();
                txtExceptionDetails.Visible = false;
                lblExceptionDetails.Visible = false;
                Height = 271;
            }
            else
            {
                picMainIcon.Image = SystemIcons.Warning.ToBitmap();
                txtExceptionDetails.Visible = true;
                lblExceptionDetails.Visible = true;
                Height = 386;
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
