﻿using System;
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
            result.Message = $"New Package {context.VersionNo} created successfully.";
            result.LogText = context.GetLogText();
            return result;
        }

        public static PreviewPackageGenerateResult CreateFailureResult(PreviewPackageGeneratorContext context,Exception ex)
        {
            var result = new PreviewPackageGenerateResult();
            result.IsSuccess = false;
            result.Message = $"Preview NuGet Package failed to create, see the log and exception text for more details.";
            result.LogText = context.GetLogText();
            result.Exception = ex;
            return result;
        }
        public PreviewPackageGenerateResult()
        {
            IsSuccess = false;
            LogText = string.Empty;
            Message = string.Empty;           
        }

        public bool IsSuccess { get; set; }
        public string LogText { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
