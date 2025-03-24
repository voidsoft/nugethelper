using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Generate
{
    public class PackageVersion
    {
        public PackageVersion()
        {
            PreviewSuffix = string.Empty;
        }
        public PackageVersion(string version)
        {
            const string errorMsg = "Invalid Version string";
            if (!TrySet(version,this))
                throw new InvalidDataException(errorMsg);
        }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }
        public string PreviewSuffix { get; set; }

        private static bool TrySet(string input, PackageVersion version)
        {            
            var versionParts = input.Split('.');
            if (versionParts.Length != 3)
                return false;

            if (int.TryParse(versionParts[0], out var major))
            {
                version.Major = major;
            }
            else
                return false;

            if (int.TryParse(versionParts[1], out var minor))
            {
                version.Minor = minor;
            }
            else
                return false;

            if (versionParts[2].Contains("-"))
            {
                var patchSplit = versionParts[2].Split('-');
                if (int.TryParse(patchSplit[0], out var patch))
                {
                    version.Patch = patch;
                }
                else
                    return false;

                version.PreviewSuffix = patchSplit[1];
            }
            else
            {
                if (int.TryParse(versionParts[2], out var patch))
                {
                    version.Patch = patch;
                }
                else
                    return false;
            }

            return true;
        }
        public static bool TryParse(string input, out PackageVersion version)
        {
            version = new PackageVersion();
            return TrySet(input, version);            
        }
        public override string ToString()
        {
            var patchValue = Patch.ToString();
            if (!string.IsNullOrEmpty(PreviewSuffix))
                patchValue += "-" + PreviewSuffix;
            return $"{Major}.{Minor}.{patchValue}";
        }
    }
}
