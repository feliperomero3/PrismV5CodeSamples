// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using UIComposition.EmployeeModule;
using UIComposition.Shell.Views;

namespace UIComposition.Shell
{
    public class UICompositionBootstrapper : UnityBootstrapper
    {
        // TODO: 02 - The Shell loads the EmployeeModule, as specified in the module catalog (ModuleCatalog.xaml).

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(ModuleInit));
        }

        protected override DependencyObject CreateShell()
        {
            // Use the container to create an instance of the shell.
            var view = Container.TryResolve<ShellView>();
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;

            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Show();
            }
        }
    }
}