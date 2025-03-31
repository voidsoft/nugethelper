using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Generate
{
    public interface IPackageGenerator
    {
        event Action<string> LogEvent;
        event Action<int, string> ProgressEvent;
        event Action<PackageGenerateResult> CompleteEvent;
        void GeneratePackage(string projectPath, string nugetPath);
    }
}
