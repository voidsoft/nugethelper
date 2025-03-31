using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Generate
{
    public class PackageGenerateException : Exception
    {
        public PackageGenerateException(string message) : base (message) 
        {

        }
        public static void ThrowIf(bool condition, string message)
        {
            if (condition)
                throw new PackageGenerateException(message);
        }
    }
}
