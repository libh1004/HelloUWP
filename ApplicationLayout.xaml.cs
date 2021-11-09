using HelloUWP.Entities;
using HelloUWP.Service;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ApplicationLayout : Page
    {
        SongService songService = new SongService();
        List<Song> listSong = new List<Song>();
        public ApplicationLayout()
        {
            this.InitializeComponent();
        }
        private void MyNavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            MyNavView.IsBackEnabled = true;
            MyNavView.IsBackButtonVisible = NavigationViewBackButtonVisible.Visible;
            if (args.IsSettingsInvoked)
            {
                //Xử lý khi click nut setting
                SongContentPage.Navigate(typeof(Pages.SettingPage), args.RecommendedNavigationTransitionInfo);
                return;
            }

            var tag = args.InvokedItemContainer.Tag.ToString();
            switch (tag)
            {
                case "home":
                    SongContentPage.Navigate(typeof(Pages.DashboardPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "createSong":
                    SongContentPage.Navigate(typeof(Pages.CreateSongPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "mySong":
                    SongContentPage.Navigate(typeof(Pages.MySongPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "listSong":
                    SongContentPage.Navigate(typeof(Pages.Admin.ListSongPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "listAccount":
                    SongContentPage.Navigate(typeof(Pages.Admin.ListAccountPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "profile":
                    SongContentPage.Navigate(typeof(Pages.ProfilePage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "login":
                    SongContentPage.Navigate(typeof(Pages.LoginPage), args.RecommendedNavigationTransitionInfo);
                    break;
                case "register":
                    SongContentPage.Navigate(typeof(Pages.RegisterPage), args.RecommendedNavigationTransitionInfo);
                    break;
            }
        }
        private void MyNavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (SongContentPage.CanGoBack)
            {
                SongContentPage.GoBack();
            }
        }
    }
}
