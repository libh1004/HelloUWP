using HelloUWP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HelloUWP
{
    public class Helper
    {
       public async void WriteFile(string token)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync("test.txt",
                    CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(file, token);
        }
        public async Task<string> ReadFile()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync("test.txt");
            return await FileIO.ReadTextAsync(file);
        }
    }
}
