using Church_Presenter.Views;

namespace Church_Presenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Wpf.Ui.Appearance.Accent.ApplySystemAccent();
            MediaSelectionFrame.Content = new MediaSelectorPage();
            LiveFrame.Content = new LivePage();


        }

    }
}