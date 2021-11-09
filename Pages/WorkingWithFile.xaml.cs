using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkingWithFile : Page
    {
        public WorkingWithFile()
        {
            this.InitializeComponent();
        }


        private async void MenuFlyoutItem_Save(object sender, RoutedEventArgs e)
        {
            // create save file picker, open windows choose file to save
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            // choose start folder to open file
            savePicker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // type file can working together
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            // name file default
            savePicker.SuggestedFileName = "New Document";
            var file = await savePicker.PickSaveFileAsync();
            if(file != null)
            {
                var contentFile = txtContent.Text;
                await FileIO.WriteTextAsync(file, contentFile);
            }
        }

        private async void MenuFlyoutItem_Open(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Downloads;
            picker.FileTypeFilter.Add(".txt");
            StorageFile storageFile = await picker.PickSingleFileAsync();
           
            if(storageFile != null)
            {
                txtContent.Text = await FileIO.ReadTextAsync(storageFile);
            }
        }
    }
}
