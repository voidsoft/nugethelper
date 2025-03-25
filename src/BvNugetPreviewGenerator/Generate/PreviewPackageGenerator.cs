using Microsoft.VisualStudio.Text.Editor.Commanding.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BvNugetPreviewGenerator.Generate
{
    class PreviewPackageGenerator
    {
        public PreviewPackageGenerateResult GeneratePackage(string projectPath, string nugetPath)
        {
            

            var context = new PreviewPackageGeneratorContext();
            context.NugetPath = nugetPath;
            context.ProjectPath = projectPath;
            context.ProjectFilename = Path.GetFileName(projectPath);
            context.TempPath = Path.GetTempPath();

            try
            {
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

                UpdateProjectVersion(context);
                RunDotNetBuild(context);
                RunNugetPush(context);
                RestoreProjectVersion(context);
                CleanUp(context);
            }
            catch (PreviewPackageGenerateException ex)
            {
                return PreviewPackageGenerateResult.CreateFailureResult(context, ex);
            }
            catch (Exception ex)
            {
                return PreviewPackageGenerateResult.CreateFailureResult(context, ex);
            }

            return PreviewPackageGenerateResult.CreateSuccessResult(context);
        }

        private void RestoreProjectVersion(PreviewPackageGeneratorContext context)
        {
            context.Log($"Restoring original version of {context.ProjectFilename}");
            SaveFile(context.ProjectPath, context.OriginalProjectContent);
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
            context.Log($"Updating Project Version in {context.ProjectFilename}");
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
        }

        private string RunDotNetBuild(PreviewPackageGeneratorContext context)
        {

            var projectPath = context.ProjectPath;
            var outputFolder = context.TempPath;
            var version = context.VersionNo;

            var output = RunTask(context, "dotnet", 
                $"build \"{projectPath}\" " +
                $"--configuration Debug " +
                $"-o:\"{outputFolder}\"");
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
            context.PackageFilename = packageFileName;

            var fullProjName = $"{outputFolder}{packageFileName}";            
            
            var sb = new StringBuilder();
            var output = RunTask(context, "dotnet", 
                $"nuget push {fullProjName} -s {context.NugetPath}");
            return output;
        }

        private void CleanUp(PreviewPackageGeneratorContext context)
        {
            context.Log("Cleaning up temporary files");
            var tempFolder = context.TempPath;
            var packageFileName = context.PackageFilename;
            var fullProjName = $"{tempFolder}{packageFileName}";
            if (File.Exists(fullProjName))
                File.Delete(fullProjName);
        }

        private string RunTask(PreviewPackageGeneratorContext context,string processName, string parameters)
        {
            try
            {
                context.Log($"Attempting to Run: {processName} {parameters}");
                var procStIfo = new ProcessStartInfo(processName, parameters);
                procStIfo.RedirectStandardOutput = true;
                procStIfo.UseShellExecute = false;
                procStIfo.CreateNoWindow = true;

                var proc = new Process();
                proc.StartInfo = procStIfo;
                proc.Start();
                proc.WaitForExit();
                var output = proc.StandardOutput.ReadToEnd();
                return output;
            }
            catch (Exception ex)
            {
                context.Log($"Exception Occured running: {processName} {parameters}");
                context.Log($"Exception Message: {ex.Message}");
                context.Log($"Stack Trace: {ex.StackTrace}");
                throw;
            }
            
        }
    }
}
