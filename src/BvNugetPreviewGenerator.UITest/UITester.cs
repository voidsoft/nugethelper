using BvNugetPreviewGenerator.Generate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BvNugetPreviewGenerator.UITest
{
    public partial class UITester: Form
    {
        public UITester()
        {
            InitializeComponent();
        }

        private void btnSuccessResult_Click(object sender, EventArgs e)
        {
            var context = new PreviewPackageGeneratorContext();
            context.Log("Some Test logging for a success");
            context.Log("More Test logging for a success");
            var result = PreviewPackageGenerateResult.CreateSuccessResult(context);
            var form = new GeneratedMessage();
            form.PreviewPackageGenerateResult = result;
            form.ShowDialog();
        }

        private void btnFail_Click(object sender, EventArgs e)
        {
            var context = new PreviewPackageGeneratorContext();
            try
            {
                var exception = new Exception("Test Exception");                
                context.Log("Some Test logging for a success");
                context.Log("More Test logging for a success");
                throw exception;
            }
            catch (Exception ex)
            {
                var result = PreviewPackageGenerateResult.CreateFailureResult(context, ex);
                var form = new GeneratedMessage();
                form.PreviewPackageGenerateResult = result;
                form.ShowDialog();
            }
            

        }

        private void btnExpectedFailureResult_Click(object sender, EventArgs e)
        {
            var exception = new PreviewPackageGenerateException("Test Exception");
            var context = new PreviewPackageGeneratorContext();
            context.Log("Some Test logging for a success");
            context.Log("More Test logging for a success");
            var result = PreviewPackageGenerateResult.CreateFailureResult(context, exception);
            var form = new GeneratedMessage();
            form.PreviewPackageGenerateResult = result;
            form.ShowDialog();
        }
    }
}
