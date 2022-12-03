using Church_Presenter.Views;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui.Mvvm.Contracts;

namespace Church_Presenter.Services
{
    internal class ApplicationBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly INavigationService _navigationService;
        private readonly IPageService _pageService;

        private INavigationWindow _navigationWindow;

        public ApplicationBackgroundService(IServiceProvider serviceProvider, INavigationService navigationService,
        IPageService pageService)
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
            _pageService = pageService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            PrepareNavigation();
            await Task.CompletedTask;

            if (!Application.Current.Windows.OfType<MainFrame>().Any())
{
                _navigationWindow = _serviceProvider.GetService(typeof(INavigationWindow)) as INavigationWindow;
                _navigationWindow!.ShowWindow();

                // NOTICE: You can set this service directly in the window 
                // _navigationWindow.SetPageService(_pageService);

                // NOTICE: In the case of this window, we navigate to the Dashboard after loading with Container.InitializeUi()
                // _navigationWindow.Navigate(typeof(Views.Pages.Dashboard));
            }

            var notifyIconManager = _serviceProvider.GetService(typeof(INotifyIconService)) as INotifyIconService;

            if (!notifyIconManager!.IsRegistered)
{
                notifyIconManager!.SetParentWindow(_navigationWindow as Window);
                notifyIconManager.Register();
            }

            await Task.CompletedTask;
        }

        private void PrepareNavigation()
        {
            _navigationService.SetPageService(_pageService);
        }
    }
}
