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
    public sealed partial class UpdateSongPage : Page
    {
        private AdminService adminService = new AdminService();
        private SongService songService = new SongService();
        private Helper helper = new Helper();
        private List<Song> listSong = new List<Song>();
        public UpdateSongPage()
        {
            this.InitializeComponent();
        }
        private async void Update_ButtonClick(object sender, RoutedEventArgs e)
        { 
            var getToken = await helper.ReadFile();
            int currentId = (int)((Button)sender).Tag;
            foreach(var song in listSong)
            {
                if(currentId == song.id)
                {
                    txtName.Text = song.name;
                    txtDescription.Text = song.description;
                    txtSinger.Text = song.singer;
                    txtAuthor.Text = song.author;
                    txtThumbnail.Text = song.thumbnail;
                    txtLink.Text = song.link;
                    txtMessage.Text = song.message;
                }
            }
            await adminService.UpdateSong(getToken, currentId, new Song
            {
                name = txtName.Text,
                description = txtDescription.Text,
                singer = txtSinger.Text,
                author = txtAuthor.Text,
                thumbnail = txtThumbnail.Text,
                link = txtLink.Text,
                message = txtMessage.Text,
            });
            ContentDialog contentDialog = new ContentDialog();
            contentDialog.Title = "Action success";
            contentDialog.Content = "Update song success";
            contentDialog.PrimaryButtonText = "Ok";
            await contentDialog.ShowAsync();
        }
    }
}
