using BvNugetPreviewGenerator.Generate;
using BvNugetPreviewGenerator.UITest.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
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
            var mock = new MockPreviewPackageGenerator(PreviewPackageGenerateResultType.Success, null);
            using (var form = new GenerateForm(mock))
            {
                form.ShowDialog();
            }
        }

        private void btnFail_Click(object sender, EventArgs e)
        {
            var context = new PackageGeneratorContext();
            try
            {
                var exception = new Exception("Test Exception");                
                throw exception;
            }
            catch (Exception ex)
            {
                var mock = new MockPreviewPackageGenerator(PreviewPackageGenerateResultType.UnexpectedFailure, ex);
                using (var form = new GenerateForm(mock))
                {
                    form.ShowDialog();
                }
            }
            

        }

        private void btnExpectedFailureResult_Click(object sender, EventArgs e)
        {
            var ex = new PackageGenerateException("Expected Failure");
            var mock = new MockPreviewPackageGenerator(PreviewPackageGenerateResultType.ExpectedFailure, ex);
            using (var form = new GenerateForm(mock))
            {
                form.ShowDialog();
            }
        }

        private void btnProgressTest_Click(object sender, EventArgs e)
        {
            var mock = new MockPreviewPackageGenerator(PreviewPackageGenerateResultType.Success, null);
            using(var form = new GenerateForm(mock))
            {
                form.ShowDialog();
            }
  
        }

        private void btnTestProgessFailure_Click(object sender, EventArgs e)
        {
            Exception testEx;
            try
            {
                var exception = new Exception("Test Exception");
                throw exception;
            }
            catch (Exception ex)
            {
                testEx = ex;
            }

            var mock = new MockPreviewPackageGenerator(PreviewPackageGenerateResultType.UnexpectedFailure, testEx);
            using (var form = new GenerateForm(mock))
            {
                form.ShowDialog();
            }
        }
    }
}
