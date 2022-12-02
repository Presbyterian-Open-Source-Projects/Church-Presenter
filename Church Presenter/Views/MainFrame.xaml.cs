using Church_Presenter.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace Church_Presenter.Views
{
    /// <summary>
    /// Interaction logic for MainFrame.xaml
    /// </summary>
    public partial class MainFrame : INavigationWindow
    {
        private readonly IThemeService _themeService;
        private readonly ITaskBarService _taskBarService;

        public MainFrameViewModel ViewModel { get; }


        public MainFrame(MainFrameViewModel viewModel, INavigationService navigationService, IPageService pageService, IThemeService themeService, ITaskBarService taskBarService, ISnackbarService snackbarService, IDialogService dialogService)
        {
            // Assign the view model
            ViewModel = viewModel;
            DataContext = this;
            _themeService = themeService;
            _taskBarService = taskBarService;

//            // Initial preparation of the window.
//            InitializeComponent();

//            // We define a page provider for navigation
//            SetPageService(pageService);

//            // If you want to use INavigationService instead of INavigationWindow you can define its navigation here.
//            navigationService.SetNavigationControl(RootNavigation);


//// Allows you to use the Dialog control defined in this window in other pages or windows
//            dialogService.SetDialogControl(RootDialog);
        }

        #region INavigationWindow methods

        public void ShowWindow()
           => Show();

        public void CloseWindow()
            => Close();

        //public Frame GetFrame()
        //    => RootFrame;

        //public INavigation GetNavigation()
        //    => RootNavigation;

        //public bool Navigate(Type pageType)
        //    => RootNavigation.Navigate(pageType);

        //public void SetPageService(IPageService pageService)
        //    => RootNavigation.PageService = pageService;

        #endregion INavigationWindow methods

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Make sure that closing this window will begin the process of closing the application.
            Application.Current.Shutdown();
        }

        private void NavigationButtonTheme_OnClick(object sender, RoutedEventArgs e)
        {
            _themeService.SetTheme(_themeService.GetTheme() == ThemeType.Dark ? ThemeType.Light : ThemeType.Dark);
        }

        private void RootNavigation_OnNavigated(INavigation sender, Wpf.Ui.Common.RoutedNavigationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"DEBUG | WPF UI Navigated to: {sender?.Current ?? null}", "Wpf.Ui.Demo");

            // This funky solution allows us to impose a negative
            // margin for Frame only for the Dashboard page, thanks
            // to which the banner will cover the entire page nicely.
            //RootFrame.Margin = new Thickness(
            //    left: 0,
            //    top: sender?.Current?.PageTag == "dashboard" ? -69 : 0,
            //    right: 0,
            //    bottom: 0);
        }

        public Frame GetFrame()
        {
            throw new NotImplementedException();
        }

        public INavigation GetNavigation()
        {
            throw new NotImplementedException();
        }

        public bool Navigate(Type pageType)
        {
            throw new NotImplementedException();
        }

        public void SetPageService(IPageService pageService)
        {
            throw new NotImplementedException();
        }

        private void TrayMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

        }
    }
}
