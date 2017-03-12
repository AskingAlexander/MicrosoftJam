using MicrosoftJam.MasterDetail;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MicrosoftJam.UtilityClasses
{
    class RegisterPage : ContentPage
    {
        Entry nameField;
        public RegisterPage()
        {
            nameField = new Entry
            {
                Text = "Ented your desired name!",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Button magicMaker = new Button
            {
                BorderRadius = 50,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                Text = "That's Me!"
            };

            magicMaker.Clicked += doMagic;

            this.Content = new StackLayout
            {
                Padding = new Thickness(20, 80),
                Spacing = 40,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    nameField,
                    magicMaker
                }
            };
        }

        private void doMagic(object sender, EventArgs e)
        {
            UserRelated.userName = nameField.Text;
            DependencyService.Get<ISaveAndLoad>().SaveText("user.txt", nameField.Text);
            App.Current.MainPage = new MainPage();
        }
    }
}