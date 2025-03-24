using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BvNugetPreviewGenerator.Options
{
    public class PreviewGeneratorOptions : DialogPage
    {
        [Category("Destination")]
        [DisplayName("Local Nuget Repository Folder")]
        [Description("This is the folder where generated preview NuGet packages will be published to, be sure to configure it in under Package Sources in the Package Manager settings.")]
        public string DestinationNugetPreviewSource
        {
            get;
            set;
        }
    }
}
