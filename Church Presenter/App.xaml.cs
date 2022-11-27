using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace Church_Presenter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {

        [STAThread]
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            host.Start();

            App app = new();

            app.InitializeComponent();


            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            app.MainWindow = mainWindow;
            mainWindow.Show();


            app.Run();
        }

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

        public static IHostBuilder CreateHostBuilder(string[] args) =>

       Host.CreateDefaultBuilder(args).
        ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); }).
            ConfigureServices((hostContext, services) =>
       {

           //services.AddSingleton<LoginView>();
           //services.AddSingleton<LoginViewModel>();
           services.AddSingleton<MainWindow>();
           //services.AddSingleton<IUserRepository, UserRepository>();
       });


    }
}