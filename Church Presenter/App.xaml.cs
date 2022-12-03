using Church_Presenter.Services;
using Church_Presenter.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

namespace Church_Presenter
{


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {

        public void MyMethod()
        {
            var ratio = Math.Max(Screen.PrimaryScreen.WorkingArea.Width / SystemParameters.PrimaryScreenWidth,
                          Screen.PrimaryScreen.WorkingArea.Height / SystemParameters.PrimaryScreenHeight);

            foreach (var screen in Screen.AllScreens)
            {

                if (!screen.Primary)
                {
                    var window = new ExtendedWindow();

                    window.Left = screen.WorkingArea.Left / ratio;
                    window.Top = screen.WorkingArea.Top / ratio;
                    window.Width = (screen.WorkingArea.Width / ratio);
                    window.Height = (screen.WorkingArea.Height / ratio);
                    window.Show();

                    window.WindowState = WindowState.Maximized;

                }

            }
        }

        private static readonly IHost _host = 

       Host.CreateDefaultBuilder().
        ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); }).
            ConfigureServices((hostContext, services) =>
       {
           // App Host
           services.AddHostedService<ApplicationBackgroundService>();

           // Theme manipulation
           services.AddSingleton<IThemeService, ThemeService>();

           // Taskbar manipulation
           services.AddSingleton<ITaskBarService, TaskBarService>();

           // Snackbar service
           services.AddSingleton<ISnackbarService, SnackbarService>();

           // Dialog service
           services.AddSingleton<IDialogService, DialogService>();

           // Service containing navigation, same as INavigationWindow... but without window
           services.AddSingleton<INavigationService, NavigationService>();

           // Tray icon
           services.AddSingleton<INotifyIconService, CustomNotifyIconService>();

           // Page resolver service
           services.AddSingleton<IPageService, PageService>();


           // Main window container with navigation
           services.AddScoped<INavigationWindow, Views.MainFrame>();
           services.AddScoped<MainFrameViewModel>();



           // Main window container with navigation
           services.AddScoped<INavigationWindow, Views.MainFrame>();

           services.AddScoped<Views.Pages.HomePage>();
           services.AddScoped<HomePageViewModel>();


       }).Build();


        public static T GetService<T>() where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }


        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}