using HelloUWP.Configuration;
using HelloUWP.Entities;
using HelloUWP.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace HelloUWP.Pages
{

    public sealed partial class ProfilePage : Page
    {
        private Helper helper = new Helper();
        private AccountService accountService = new AccountService();
        public ProfilePage()
        {
            this.InitializeComponent();
            this.Loaded += LoadProfile;
        }
        private async void LoadProfile(object sender, RoutedEventArgs e)
        {
            var token = await helper.ReadFile();
            var account = await accountService.GetProfile(token);
            firstName.Text = account.firstName;
            lastName.Text = account.lastName;
            email.Text = account.email;
            address.Text = account.address;
            phone.Text = account.phone;
            avatar.Source = new BitmapImage(new Uri(account.avatar));
            gender.Text = account.GetGenderAsString();
            birthday.Text = account.birthday;
            status.Text = account.GetStatusAsString();
        }
        private void EditProfile_ButtonClick(object sender, RoutedEventArgs e)
        {
            ProfileContent.Navigate(typeof(EditProfilePage));
        }
    }
}
