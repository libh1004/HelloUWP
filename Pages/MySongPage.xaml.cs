using HelloUWP.Entities;
using HelloUWP.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace HelloUWP.Pages
{
    public sealed partial class MySongPage : Page
    {
        private SongService songService = new SongService();
        List<Song> listMySong = new List<Song>();
        public MySongPage()
        {
            this.InitializeComponent();
            this.Loaded += LoadMySong;
        }
        private async void LoadMySong(object sender, RoutedEventArgs e)
        {
            var list = await songService.FindAllMySong(LoginPage.AccessToken);
            MySong.ItemsSource = list;
            Uri pathUri = new Uri(list[0].link);
            MySongMediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
            MySongMediaPlayer.MediaPlayer.Play();
        }
        private void MySong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Song currentSong = (Song)MySong.SelectedItem;
            MySongMediaPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
            MySongMediaPlayer.MediaPlayer.Play();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            MySongMediaPlayer.MediaPlayer.Pause();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (MySongMediaPlayer.MediaPlayer.Source != null)
            {
                MySongMediaPlayer.MediaPlayer.Play();
            }
        }
        private void Previous_ButtonClick(object sender, RoutedEventArgs e)
        {
            MySong.SelectedIndex--;
            for (var i = 1; i < listMySong.Count; i++)
            {
                if (MySong.SelectedIndex - 1 == listMySong[i].id)
                {
                    var previousSong = listMySong[i].name;
                }
            }
        }
        private void Next_ButtonClick(object sender, RoutedEventArgs e)
        {
            MySong.SelectedIndex++;
            for (var i = listMySong.Count; i >= 1; i--)
            {
                if (MySong.SelectedIndex + 1 == listMySong[i].id)
                {
                    var nextSong = listMySong[i].name;
                }
            }
        }
    }
}
