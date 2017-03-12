using MicrosoftJam.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MicrosoftJam.MasterDetail
{
    class ProfilePage : ContentPage
    {
        Label totalScore;
        public ProfilePage()
        {
            Image playerAvatar = new Image
            {
                Source = ImageSource.FromFile("avatar.png"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Label playerName = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = UtilityClasses.UserRelated.userName
            };

            totalScore = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = UtilityClasses.ScoreRelated.totalScore.ToString()
            };

            Button refreshButton = new Button
            {
                BorderRadius = 50,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                Text = "Refresh the Data!"
            };
            refreshButton.Clicked += updateData;

            this.Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 20,
                Children =
                {
                    playerAvatar,
                    playerName,
                    totalScore,
                    refreshButton
                }
            };
        }

        public void updateData(object sender, EventArgs e)
        {
            ScoreRelated.UpdateScore();
            totalScore.Text = ScoreRelated.totalScore.ToString();
        }
    }
}
