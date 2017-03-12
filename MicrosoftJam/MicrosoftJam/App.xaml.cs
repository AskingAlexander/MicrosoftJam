using MicrosoftJam.MasterDetail;
using MicrosoftJam.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MicrosoftJam
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            ScoreRelated mayNeed = new ScoreRelated();

            if (UtilityClasses.UserRelated.IsLoggedIn())
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new UtilityClasses.RegisterPage();
            }
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
            ScoreRelated.UpdateScore();

        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
