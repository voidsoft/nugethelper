using BvNugetPreviewGenerator.Generate;
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
            var context = new PreviewPackageGeneratorContext();
            var result = PreviewPackageGenerateResult.CreateSuccessResult(context);
            var form = new GenerateForm();
            form.SetResult(result);
            form.ShowDialog();
        }

        private void btnFail_Click(object sender, EventArgs e)
        {
            var context = new PreviewPackageGeneratorContext();
            try
            {
                var exception = new Exception("Test Exception");                
                throw exception;
            }
            catch (Exception ex)
            {
                var result = PreviewPackageGenerateResult.CreateFailureResult(context, ex);
                var form = new GenerateForm();
                form.SetResult(result);
                form.ShowDialog();
            }
            

        }

        private void btnExpectedFailureResult_Click(object sender, EventArgs e)
        {
            var exception = new PreviewPackageGenerateException("Test Exception");
            var context = new PreviewPackageGeneratorContext();
            
            var result = PreviewPackageGenerateResult.CreateFailureResult(context, exception);
            var form = new GenerateForm();
            form.LogEvent("Some Test logging for a success");
            form.LogEvent("More Test logging for a success");
            form.SetResult(result);
            form.ShowDialog();
        }

        private void btnProgressTest_Click(object sender, EventArgs e)
        {
            var context = new PreviewPackageGeneratorContext();
            var result = PreviewPackageGenerateResult.CreateSuccessResult(context);
            var form = new GenerateForm();            
            form.Show();
            form.StartProgress();
            form.LogEvent("Starting Test");
            form.SetProgress(10,"First Stuff");
            form.LogEvent("RUnning Process 1");
            Thread.Sleep(1000);
            form.LogEvent("Finished Process 1");
            form.SetProgress(30, "Second Stuff");
            Thread.Sleep(1000);
            form.LogEvent("Running Process 2");
            Thread.Sleep(1000);
            form.LogEvent("Finished Process 2");
            form.SetProgress(80, "Last Stuff");
            form.LogEvent("Running Process 3");
            Thread.Sleep(2000);
            form.LogEvent("Process 3 Stage 1");
            Thread.Sleep(2000);
            form.LogEvent("Process 3 Stage 2");
            Thread.Sleep(2000);
            form.LogEvent("Process 3 Stage 3");
            form.LogEvent("Finished Process 3");
            Thread.Sleep(2000);
            form.SetProgress(100, "Done");
            Thread.Sleep(2000);
            form.SetResult(result);
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

            var context = new PreviewPackageGeneratorContext();
            var result = PreviewPackageGenerateResult.CreateFailureResult(context, testEx);
            var form = new GenerateForm();
            form.Show();
            form.StartProgress();
            form.LogEvent("Starting Test");
            form.SetProgress(10, "First Stuff");
            form.LogEvent("RUnning Process 1");
            Thread.Sleep(1000);
            form.LogEvent("Finished Process 1");
            form.SetProgress(30, "Second Stuff");
            Thread.Sleep(500);
            form.LogEvent("Running Process 2");
            Thread.Sleep(500);
            form.LogEvent("Finished Process 2");
            form.SetProgress(80, "Last Stuff");
            form.LogEvent("Running Process 3");
            Thread.Sleep(300);
            form.LogEvent("Process 3 Stage 1");
            Thread.Sleep(800);
            form.LogEvent("Process 3 Stage 2");
            Thread.Sleep(1000);
            form.LogEvent("Process 3 Stage 3");
            form.LogEvent("Finished Process 3");
            Thread.Sleep(1000);
            form.SetProgress(100, "Done");
            form.SetResult(result);
        }
    }
}
