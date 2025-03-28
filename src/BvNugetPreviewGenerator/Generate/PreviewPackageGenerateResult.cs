using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Generate
{
    public class PreviewPackageGenerateResult
    {
        public static PreviewPackageGenerateResult CreateSuccessResult(PreviewPackageGeneratorContext context)
        {
            var result = new PreviewPackageGenerateResult();
            result.IsSuccess = true;
            result.Message = $"New Package {context.PackageFilename} created successfully.";
            return result;
        }

        public static PreviewPackageGenerateResult CreateFailureResult(PreviewPackageGeneratorContext context,Exception ex)
        {
            var result = new PreviewPackageGenerateResult();
            result.IsSuccess = false;
            if (ex is PreviewPackageGenerateException)
            {
                result.IsExpectedFailure = true;
                result.Message = ex.Message;
            }
            else
            {
                result.Message = $"An unexpected error occured attempting to " +
                    $"create the Preview Nuget Package, see the log and exception " +
                    $"text for more details.";
            }
            
            result.Exception = ex;
            return result;
        }
        public PreviewPackageGenerateResult()
        {
            IsSuccess = false;
            Message = string.Empty;           
        }

        public bool IsSuccess { get; set; }
        public bool IsExpectedFailure { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
