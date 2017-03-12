using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MicrosoftJam.GamePages.AndradaH
{
    class AndradaH : ContentPage
    {
        Label textBasic;
        public AndradaH()
        {
            textBasic = new Label {
                Text = "Eu sunt un text",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("FFFAFF"),
                BackgroundColor = Color.FromHex("00090C")
            };

            Button myButton = new Button {
            Text = "Eu schimb culoarea textului"
            };

            myButton.Clicked += SchimbaCuloarea;

            this.Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    myButton,
                    textBasic
                }
            };

        }

        private void SchimbaCuloarea(object sender, EventArgs e)
        {
            textBasic.TextColor = Color.FromHex("FC5130");
        }
    }
}
