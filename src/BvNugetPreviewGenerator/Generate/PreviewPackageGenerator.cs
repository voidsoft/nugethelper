using Microsoft.VisualStudio.Text.Editor.Commanding.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BvNugetPreviewGenerator.Generate
{
    public class PreviewPackageGenerator
    {
        public event Action<string> LogEvent;
        public event Action<int, string> ProgressEvent;
        public event Action<PreviewPackageGenerateResult> CompleteEvent;
        public void GeneratePackage(string projectPath, string nugetPath)
        {
            

            var context = new PreviewPackageGeneratorContext();
            context.NugetPath = nugetPath;
            context.ProjectPath = projectPath;
            context.ProjectFilename = Path.GetFileName(projectPath);
            context.TempPath = Path.GetTempPath();

            try
            {
                Progress(0, "Performing Initial Checks");
                PreviewPackageGenerateException
                    .ThrowIf(string.IsNullOrWhiteSpace(nugetPath),
                        "No NuGet repository folder has been specified, please configure a folder " +
                        "Local Nuget Repository Folder in Nuget Package Manager > Nuget Preview Generator.");

                PreviewPackageGenerateException
                    .ThrowIf(!Directory.Exists(nugetPath),
                        "The configured Local Nuget Repository Folder does not exist, please check the " +
                        "configured folder in Nuget Package Manager > Nuget Preview Generator is correct.");

                PreviewPackageGenerateException
                    .ThrowIf(string.IsNullOrWhiteSpace(projectPath),
                        "No project file was specified for this package.");
                Progress(5, "Initial Checks Complete");
                Progress(10, "Updating Project Version");
                UpdateProjectVersion(context);                
                Progress(15, "Building Project");
                RunDotNetBuild(context);
                Progress(75, "Pushing Project to Nuget");
                RunNugetPush(context);
                Progress(85, "Restoring Project");
                RestoreProjectVersion(context);
                Progress(95, "Cleaning Up");
                CleanUp(context);
                Progress(100, "Generation Complete");                
            }
            catch (PreviewPackageGenerateException ex)
            {
                var failResult = PreviewPackageGenerateResult.CreateFailureResult(context, ex);
                CompleteEvent(failResult);
            }
            catch (Exception ex)
            {
                var failResult = PreviewPackageGenerateResult.CreateFailureResult(context, ex);
                CompleteEvent(failResult);
            }

            var result = PreviewPackageGenerateResult.CreateSuccessResult(context);
            CompleteEvent(result);
        }

        private void RestoreProjectVersion(PreviewPackageGeneratorContext context)
        {
            Log($"Restoring original version of {context.ProjectFilename}");
            SaveFile(context.ProjectPath, context.OriginalProjectContent);
            Log($"Restoration Complete");
        }
        private string LoadFile(string fileName)
        {
            var reader = new StreamReader(fileName);
            var data = reader.ReadToEnd();
            reader.Close();
            return data;
        }
        public void SaveFile(string fileName, string content)
        {
            var writer = new StreamWriter(fileName, false);
            writer.Write(content);
            writer.Close();
        }
        private void UpdateProjectVersion_AddOrEditNode(XmlNode parent, string nodeName, string nodeValue)
        {
            var doc = parent.OwnerDocument;
            var dtNode = parent.SelectSingleNode(nodeName);
            if (dtNode != null)
            {
                dtNode.InnerText = nodeValue;
            }
            else
            {
                var newNode = doc.CreateElement(nodeName);
                newNode.InnerText = nodeValue;
                parent.AppendChild(newNode);
            }
        }


        private void UpdateProjectVersion(PreviewPackageGeneratorContext context)
        {
            Log($"Updating Project Version in {context.ProjectFilename}");
            context.OriginalProjectContent = LoadFile(context.ProjectPath);
            var doc = new XmlDocument();
            doc.LoadXml(context.OriginalProjectContent);
            var versionNode = doc.SelectSingleNode("/Project/PropertyGroup/Version");
            PreviewPackageGenerateException
                .ThrowIf(versionNode == null, 
                "No version number found, project must contain a version number in the " +
                "format Major.Minor.Patch e.g. 1.5.3");

            if (!PackageVersion.TryParse(versionNode.InnerText, out var version))
                throw new PreviewPackageGenerateException("Version number did not match " +
                    "expected format. Project must contain a version number in the format " +
                    "Major.Minor.Patch e.g. 1.5.3");

            var dateStr = DateTime.Now.ToString("yyyyMMddHHmm");
            version.PreviewSuffix = $"preview{dateStr}";
            versionNode.InnerText = version.ToString();
            var propGroupNode = doc.SelectSingleNode("/Project/PropertyGroup");
            UpdateProjectVersion_AddOrEditNode(propGroupNode,
                "DebugType", "embedded");
            UpdateProjectVersion_AddOrEditNode(propGroupNode,
                "GeneratePackageOnBuild", "true");
            doc.Save(context.ProjectPath);
            context.VersionNo = version.ToString();
            Log($"Update Complete");
        }

        private string RunDotNetBuild(PreviewPackageGeneratorContext context)
        {
            Log($"Running DotNet Build Of {context.ProjectFilename}");
            var projectPath = context.ProjectPath;
            var outputFolder = context.TempPath;
            var version = context.VersionNo;

            var output = RunTask(context, "dotnet", 
                $"build \"{projectPath}\" " +
                $"--configuration Debug " +
                $"-o:\"{outputFolder}\"");
            Log($"DotNet Build Complete");
            return output;
        }

        private string RunNugetPush(PreviewPackageGeneratorContext context)
        {
            var projectPath = context.ProjectPath;
            var outputFolder = context.TempPath;
            var version = context.VersionNo;            
            var lastDirMarker = projectPath.LastIndexOf("\\");
            var path = projectPath.Substring(0, lastDirMarker);
            var fileName = projectPath.Substring(lastDirMarker + 1);
            var lastDot = fileName.LastIndexOf(".");
            var projectName = fileName.Substring(0, lastDot);
            var packageFileName = $"{projectName}.{version}.nupkg";
            Log($"Running DotNet Push Of {packageFileName}");
            context.PackageFilename = packageFileName;

            var fullProjName = $"{outputFolder}{packageFileName}";            
            
            var sb = new StringBuilder();
            var output = RunTask(context, "dotnet", 
                $"nuget push {fullProjName} -s {context.NugetPath}");
            Log($"DotNet Push Complete");
            return output;
        }

        private void CleanUp(PreviewPackageGeneratorContext context)
        {
            Log("Cleaning up temporary files");
            var tempFolder = context.TempPath;
            var packageFileName = context.PackageFilename;
            var fullProjName = $"{tempFolder}{packageFileName}";
            if (File.Exists(fullProjName))
                File.Delete(fullProjName);
            Log("Cleanup Complete");
        }

        private string RunTask(PreviewPackageGeneratorContext context,string processName, string parameters)
        {
            try
            {
                Log($"Attempting to Run: {processName} {parameters}");
                var procStIfo = new ProcessStartInfo(processName, parameters);
                procStIfo.RedirectStandardOutput = true;
                procStIfo.UseShellExecute = false;
                procStIfo.CreateNoWindow = true;

                using (var proc = new Process())
                {
                    proc.StartInfo = procStIfo;
                    proc.Start();                    
                    proc.WaitForExit();
                    var output = proc.StandardOutput.ReadToEnd();
                    return output;
                }
            }
            catch (Exception ex)
            {
                Log($"Exception Occured running: {processName} {parameters}");
                Log($"Exception Message: {ex.Message}");
                Log($"Stack Trace: {ex.StackTrace}");
                throw;
            }
            
        }

        public void Log(string message)
        {
            if (LogEvent != null)
                LogEvent(message);
        }

        public void Progress(int progress,string message)
        {
            if (ProgressEvent != null)
                ProgressEvent(progress,message);
        }

        public void Complete(PreviewPackageGenerateResult result)
        {
            if (CompleteEvent != null)
                CompleteEvent(result);
        }
    }
}
