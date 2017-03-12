using MicrosoftJam.UtilityClasses;
using MicrosoftJam.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace MicrosoftJam.UWP
{
    class SaveAndLoad : ISaveAndLoad
    {
        public string LoadText(string filename)
        {
            var task = LoadTextAsync(filename);
            task.Wait(); // HACK: to keep Interface return types simple (sorry!)
            return task.Result;
        }
        async Task<string> LoadTextAsync(string fileName)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile ticketsFile = 
                await storageFolder.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            
            //read file
            string savedTickets = await Windows.Storage.FileIO.ReadTextAsync(ticketsFile);

            return savedTickets;
        }
        public async void SaveText(string filename, string text)
        {
            Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile ticketsFile =
                await storageFolder.CreateFileAsync(filename,
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);

            //Write data to the file
            await Windows.Storage.FileIO.WriteTextAsync(ticketsFile, text);
        }
    }
}
