using HelloUWP.Entities;
using HelloUWP.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace HelloUWP.Pages.Admin
{
    public sealed partial class ListSongPage : Page
    {
        private AdminService adminService = new AdminService();
        private Helper helper = new Helper();
        List<Song> list = new List<Song>();
        private Token token = new Token();
        public ListSongPage()
        {
            this.InitializeComponent();
            this.Loaded += LoadSong; // document ready trong js
        }
        private async void LoadSong(object sender, RoutedEventArgs e)
        {
            var token = await helper.ReadFile();
            var listsong = await adminService.FindAllSong(token);
            ListSong.ItemsSource = listsong;
            Uri pathUri = new Uri(listsong[0].link);
            MyMediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
            MyMediaPlayer.MediaPlayer.Play();
        }
        private void ListSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Song currentSong = (Song)ListSong.SelectedItem;
            MyMediaPlayer.MediaPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
            MyMediaPlayer.MediaPlayer.Play();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            MyMediaPlayer.MediaPlayer.Pause();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (MyMediaPlayer.MediaPlayer.Source != null)
            {
                MyMediaPlayer.MediaPlayer.Play();
            }
        }
        private void Previous_ButtonClick(object sender, RoutedEventArgs e)
        {
            ListSong.SelectedIndex--;
            for (var i = 1; i < list.Count; i++)
            {
                if (ListSong.SelectedIndex - 1 == list[i].id)
                {
                    var previousSong = list[i].name;
                }
            }
        }
        private void Next_ButtonClick(object sender, RoutedEventArgs e)
        {
            ListSong.SelectedIndex++;
            for (var i = list.Count; i >= 1; i--)
            {
                if (ListSong.SelectedIndex + 1 == list[i].id)
                {
                    var nextSong = list[i].name;
                }
            }
        }
        private void EditSong_ButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UpdateSongPage));
            int currentId = (int)((Button)sender).Tag;
        }
        private async void DeleteSong_ButtonClick(object sender, RoutedEventArgs e)
        {
            var getToken = await helper.ReadFile();
            int currentId = (int)((Button)sender).Tag;
            await adminService.DeleteSong(getToken, currentId);
            ContentDialog contentDialog = new ContentDialog();
            foreach (var song in list)
            {
                if (currentId == song.id && token.access_token != null)
                {
                    contentDialog.Title = "confirm action";
                    contentDialog.Content = $"are you sure you want to delete {song.name} song";
                    contentDialog.PrimaryButtonText = "ok";
                    contentDialog.SecondaryButtonText = "cancel";
                    await contentDialog.ShowAsync();
                    Frame.Navigate(typeof(ListSongPage));
                }
                else
                {
                    contentDialog.Content = "song not found.";
                    await contentDialog.ShowAsync();
                }
            }
        }

    }
}
