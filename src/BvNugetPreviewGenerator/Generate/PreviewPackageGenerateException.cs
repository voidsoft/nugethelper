using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Generate
{
    public class PreviewPackageGenerateException : Exception
    {
        public PreviewPackageGenerateException(string message) : base (message) 
        {

        }
        public static void ThrowIf(bool condition, string message)
        {
            if (condition)
                throw new PreviewPackageGenerateException(message);
        }
    }
}
