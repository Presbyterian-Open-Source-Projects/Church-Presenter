using Church_Presenter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
namespace Church_Presenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Wpf.Ui.Appearance.Accent.ApplySystemAccent();
            MediaSelectionFrame.Content = new MediaSelectorPage();
            MyMethod();
        }

        public void MyMethod()
        {
            var a = Screen.AllScreens;
            var ratio = Math.Max(Screen.PrimaryScreen.WorkingArea.Width / SystemParameters.PrimaryScreenWidth,
                            Screen.PrimaryScreen.WorkingArea.Height / SystemParameters.PrimaryScreenHeight);

        }
    }
}
