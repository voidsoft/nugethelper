using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Generate
{
    public enum PreviewPackageGenerateResultType
    {
        Success,
        ExpectedFailure,
        UnexpectedFailure
    }

    public class PackageGenerateResult
    {
        public static PackageGenerateResult CreateSuccessResult(PackageGeneratorContext context)
        {
            var result = new PackageGenerateResult();
            result.ResultType = PreviewPackageGenerateResultType.Success;
            result.Message = $"New Package {context.PackageFilename} created successfully.";
            return result;
        }

        public static PackageGenerateResult CreateExpectedFailureResult(PackageGeneratorContext context,Exception ex)
        {
            var result = new PackageGenerateResult();
            result.ResultType = PreviewPackageGenerateResultType.ExpectedFailure;
            result.Message = ex.Message;                        
            return result;
        }

        public static PackageGenerateResult CreateUnexpectedFailureResult(PackageGeneratorContext context, Exception ex)
        {
            var result = new PackageGenerateResult();
            result.ResultType = PreviewPackageGenerateResultType.UnexpectedFailure;            
            return result;
        }


        public PackageGenerateResult()
        {
            Message = string.Empty;           
        }

        public PreviewPackageGenerateResultType ResultType { get; set; }
        public string Message { get; set; }
    }
}
