using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BvNugetPreviewGenerator.Generate;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace BvNugetPreviewGenerator
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class GeneratePreviewNugetCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("be00d81f-7240-4b92-aba6-995490d5063b");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratePreviewNugetCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private GeneratePreviewNugetCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static GeneratePreviewNugetCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private System.IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in Command1's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new GeneratePreviewNugetCommand(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            EnvDTE.DTE service = (EnvDTE.DTE)ServiceProvider.GetService(typeof(EnvDTE.DTE));
            var selectedItems = service.SelectedItems;
            EnvDTE.SelectedItem projectItem = null;

            foreach (EnvDTE.SelectedItem item in selectedItems)
            {
                projectItem = item;
                continue;
            }

            if (projectItem == null || 
                projectItem.Project == null || 
                string.IsNullOrEmpty(projectItem.Project.FileName))
                return;

            // For now it's easiest just to run the process in the main thread
            // in future we can run in async.
            var bvPreviewPackage = this.package as BvNugetPreviewGeneratorPackage;
            var projectFile  = projectItem.Project.FileName;           
            var generator = new PreviewPackageGenerator();
            var message = generator.GeneratePackage(projectFile, bvPreviewPackage.DestinationNugetPreviewSource);
            var messageBox = new GeneratedMessage();
            messageBox.PreviewPackageGenerateResult = message;
            messageBox.ShowDialog();
        }

    }
}
