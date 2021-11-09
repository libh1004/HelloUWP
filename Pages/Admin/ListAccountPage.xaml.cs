using HelloUWP.Entities;
using HelloUWP.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace HelloUWP.Pages.Admin
{
    public sealed partial class ListAccountPage : Page
    {
        private AdminService adminService = new AdminService();
        private Helper helper = new Helper();
        private Account account = new Account();
        public ListAccountPage()
        {
            this.InitializeComponent();
            this.Loaded += LoadAccounts;
        }
        private async void LoadAccounts(object sender, RoutedEventArgs e)
        {
            var getToken = await helper.ReadFile();
            var list = await adminService.FindAllAccount(getToken);
            ListAccountAdmin.ItemsSource = list;
        }
    }
}
