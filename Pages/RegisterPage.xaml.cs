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

namespace HelloUWP.Pages
{
    public sealed partial class RegisterPage : Page
    {
        private int choosedGender = 0;
        private int choosedStatus = 0;
        private AccountService accountService = new AccountService();
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private async void Register_ButtonClick(object sender, RoutedEventArgs e)
        {
            var result = await accountService.Register(new Entities.Account
            {
                role = 1,
                firstName = txtFirstName.Text,
                lastName = txtLastName.Text,
                password = txtPassword.Password.ToString(),
                resetPassword = txtPassword_Copy2.ToString(),
                address = txtAddress.Text,
                phone = txtPhone.Text,
                avatar = txtAvatar.Text,
                gender = (GenderValue)choosedGender,
                email = txtEmail.Text,
                birthday = datePickerBirthday.SelectedDate.Value.ToString("yyyy-MM-dd"),
                status = (StatusValue)choosedStatus
            }) ;
            if (result)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Action success!";
                dialog.Content = "Register success!";
                dialog.PrimaryButtonText = "Ok";
                await dialog.ShowAsync();
                Frame.Navigate(typeof(Pages.Admin.ListSongPage));
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            switch (radioButton.Tag)
            {
                case "male":
                    choosedGender = 1;
                    break;
                case "female":
                    choosedGender = 0;
                    break;
            }
        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            switch (radioButton.Tag)
            {
                case "active":
                    choosedGender = 1;
                    break;
                case "deactive":
                    choosedGender = 0;
                    break;
                case "delected":
                    choosedGender = -1;
                    break;
            }
        }
    }
}
