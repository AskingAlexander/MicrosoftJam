using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Xamarin.Forms;
using MicrosoftJam.Droid;
using MicrosoftJam.UtilityClasses;
using System.IO;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace MicrosoftJam.Droid
{
    class SaveAndLoad : ISaveAndLoad
    {
        public void SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }
        public string LoadText(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            try
            {
                return System.IO.File.ReadAllText(filePath);
            }
            catch
            {
                return "";
            }

        }
    }
}