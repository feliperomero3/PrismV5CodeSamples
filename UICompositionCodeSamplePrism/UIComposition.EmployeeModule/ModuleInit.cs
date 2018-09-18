// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using UIComposition.EmployeeModule.Controllers;
using UIComposition.EmployeeModule.Services;
using UIComposition.EmployeeModule.Views;

namespace UIComposition.EmployeeModule
{
    public class ModuleInit : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager  _regionManager;

        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private MainRegionController _mainRegionController;

        public ModuleInit(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            // Register the EmployeeDataService concrete type with the container.
            // Change this to swap in another data service implementation.
            _container.RegisterType<IEmployeeDataService, EmployeeDataService>();

            // This is an example of View Discovery which associates the specified view type
            // with a region so that the view will be automatically added to the region when
            // the region is first displayed.

            // TODO: 03 - The EmployeeModule configures the EmployeeListView to automatically appear in the Left region (using View Discovery).
            // Show the Employee List view in the shell's left hand region.
            _regionManager.RegisterViewWithRegion(RegionNames.LeftRegion, () => _container.Resolve<EmployeeListView>());

            // TODO: 04 - The EmployeeModule defines a controller class, MainRegionController, which programmatically displays views in the Main region (using View Injection).
            // Create the main region controller.
            // This is used to programmatically coordinate the view
            // in the main region of the shell.
            _mainRegionController = _container.Resolve<MainRegionController>();

            // TODO: 08 - The EmployeeModule configures the EmployeeDetailsView and EmployeeProjectsView to automatically appear in the Tab region (using View Discovery).
            // Show the Employee Details and Employee Projects view in the tab region.
            // The tab region is defined as part of the Employee Summary view which is only
            // displayed once the user has selected an employee in the Employee List view.
            _regionManager.RegisterViewWithRegion(RegionNames.TabRegion,
                () => _container.Resolve<EmployeeDetailsView>());
            _regionManager.RegisterViewWithRegion(RegionNames.TabRegion,
                () => _container.Resolve<EmployeeProjectsView>());
        }
    }
}