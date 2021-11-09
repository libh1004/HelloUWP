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
    public sealed partial class CreateSongPage : Page
    {
        private SongService songService = new SongService();
        private Helper helper = new Helper();
        public CreateSongPage()
        {
            this.InitializeComponent();
        }
        public async void Save_ButtonClick(object sender, RoutedEventArgs e)
        {
            await songService.CreateMySong(new Song
            {
                name = txtName.Text,
                description = txtDescription.Text,
                singer = txtSinger.Text,
                author = txtAuthor.Text,
                thumbnail = txtThumbnail.Text,
                link = txtLink.Text,
                message = txtMessage.Text,
            }, helper.ReadFile().Result);
            ContentDialog contentDialog = new ContentDialog();
            contentDialog.Title = "Action success";
            contentDialog.Content = "Create new song success";
            contentDialog.PrimaryButtonText = "Ok";
            await contentDialog.ShowAsync();
        }
 
    }
}
