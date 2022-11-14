using System;
using System.Windows;
using System.Windows.Forms;

namespace Church_Presenter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

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
    }
}