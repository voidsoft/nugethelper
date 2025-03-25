using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Generate
{
    public class PreviewPackageGeneratorContext
    {
        public PreviewPackageGeneratorContext()
        {
            ProjectPath = string.Empty;
            VersionNo = string.Empty;
            OriginalProjectContent = string.Empty;
            _LogText = new StringBuilder();
        }

        private StringBuilder _LogText { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectFilename { get; set; }
        public string NugetPath { get; set; }   
        public string VersionNo { get; set; }
        public string OriginalProjectContent { get; set; }
        public string TempPath { get; set; }
        public string PackageFilename { get; set; }

        public void Log(string message)
        {
            _LogText.AppendLine(message);
        }

        public string GetLogText()
        {
            return _LogText.ToString();
        }
    }
}
