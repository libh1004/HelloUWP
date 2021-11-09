using HelloUWP.Configuration;
using HelloUWP.Entities;
using HelloUWP.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Navigation;


namespace HelloUWP.Pages
{
    public sealed partial class LoginPage : Page
    {
        public static string AccessToken = "";
        private AccountService accountService = new AccountService();
        public LoginPage()
        {
            this.InitializeComponent();
        }
        public async void Login_ButtonClick(object sender, RoutedEventArgs e)
        {
            var token = await accountService.Login(txtEmail.Text, txtPassword.Password.ToString());
            ContentDialog dialog = new ContentDialog();
            if (token.access_token == null)
            {
                dialog.Title = "Action fail!";
                dialog.Content = "Login fails: Wrong information!";
                dialog.PrimaryButtonText = "Ok";
                await dialog.ShowAsync();
            }
            else
            {
                AccessToken = token.access_token;
                dialog.Title = "Action success!";
                dialog.Content = "Login success!";
                dialog.PrimaryButtonText = "Ok";
                await dialog.ShowAsync();
            }
        }
       
    }
}
