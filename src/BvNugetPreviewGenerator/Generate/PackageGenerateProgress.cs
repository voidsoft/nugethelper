using Microsoft.VisualStudio.RpcContracts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Generate
{
    public class PackageGenerateProgress
    {
        public PackageGenerateProgress(string logmessage)
        {
            IsUpdate = false;
            LogMessage = logmessage;
        }

        public PackageGenerateProgress(string logmessage,bool isUpdate)
        {
            IsUpdate = isUpdate;
            LogMessage = logmessage;
        }
        public bool IsUpdate { get; set; }
        public string LogMessage { get; set; }
    }
}
