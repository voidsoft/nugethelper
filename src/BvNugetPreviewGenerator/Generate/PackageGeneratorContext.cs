using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Generate
{
    public class PackageGeneratorContext
    {
        public PackageGeneratorContext()
        {
            ProjectPath = string.Empty;
            VersionNo = string.Empty;
            OriginalProjectContent = string.Empty;
        }

        public string ProjectPath { get; set; }
        public string ProjectFilename { get; set; }
        public string NugetPath { get; set; }   
        public string VersionNo { get; set; }
        public string OriginalProjectContent { get; set; }
        public string TempPath { get; set; }
        public string PackageFilename { get; set; }

    }
}
