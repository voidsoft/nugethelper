using BvNugetPreviewGenerator.Generate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BvNugetPreviewGenerator.UITest.Mocks
{
    class MockPreviewPackageGenerator : IPackageGenerator
    {
        public event Action<string> LogEvent;
        public event Action<int, string> ProgressEvent;
        public event Action<PackageGenerateResult> CompleteEvent;

        private PreviewPackageGenerateResultType _ResultType;
        private Exception _ex;

        public MockPreviewPackageGenerator(PreviewPackageGenerateResultType resulttype, Exception ex)
        {
            _ResultType = resulttype;
            _ex = ex;
        }

        public void GeneratePackage(string projectPath, string nugetPath)
        {
            var context = new PackageGeneratorContext();
            Log("Starting Test");
            Progress(10, "First Stuff");
            Log("RUnning Process 1");
            Thread.Sleep(200);
            Log("Finished Process 1");
            Progress(30, "Second Stuff");
            Thread.Sleep(200);
            Log("Running Process 2");
            Thread.Sleep(200);
            Log("Finished Process 2");
            Progress(80, "Last Stuff");
            Log("Running Process 3");
            Thread.Sleep(500);
            Log("Process 3 Stage 1");
            Thread.Sleep(500);
            Log("Process 3 Stage 2");
            Thread.Sleep(500);
            Log("Process 3 Stage 3");
            Log("Finished Process 3");
            Thread.Sleep(500);
            Progress(100, "Done");
            Thread.Sleep(500);


            PackageGenerateResult result;            
            if (_ResultType == PreviewPackageGenerateResultType.Success) 
            {
                result = PackageGenerateResult.CreateSuccessResult(context);
            } 
            else if (_ResultType == PreviewPackageGenerateResultType.ExpectedFailure)
            {
                result = PackageGenerateResult.CreateExpectedFailureResult(context, _ex);
            } 
            else 
            {
                result = PackageGenerateResult.CreateUnexpectedFailureResult(context, _ex);
            }
            CompleteEvent(result);
        }

        private void Progress(int progress, string message)
        {
            if (ProgressEvent != null)
                ProgressEvent(progress,message);
        }

        private void Log(string message)
        {
            if (LogEvent != null)
                LogEvent(message);
        }
    }
}
