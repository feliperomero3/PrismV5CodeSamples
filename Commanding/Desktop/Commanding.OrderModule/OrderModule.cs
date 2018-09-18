// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Commanding.Modules.Order.Services;
using Commanding.Modules.Order.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Commanding.Modules.Order
{
    public class OrderModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public OrderModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<IOrdersRepository, OrdersRepository>(new ContainerControlledLifetimeManager());

            // Show the Orders Editor view in the shell's main region.
            _regionManager.RegisterViewWithRegion("MainRegion",
                () => _container.Resolve<OrdersEditorView>());

            // Show the Orders Toolbar view in the shell's toolbar region.
            _regionManager.RegisterViewWithRegion("GlobalCommandsRegion",
                () => _container.Resolve<OrdersToolBar>());
        }
    }
}
