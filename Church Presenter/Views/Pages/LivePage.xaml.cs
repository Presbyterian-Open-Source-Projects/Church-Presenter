using System.Windows.Controls;

namespace Church_Presenter.Views
{
    /// <summary>
    /// Interaction logic for LivePage.xaml
    /// </summary>
    public partial class LivePage : Page
    {
        public LivePage()
        {
            InitializeComponent();
            LiveOutput.Content = new LiveOutputPage();
        }
    }
}