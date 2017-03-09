using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MicrosoftJam.GamePages.AlexandruP
{
    class AlexandruP : ContentPage
    {
        static Boolean gotOk = true;
        static int score = 0;
        Label theCommand;
        Image mainImage;
        Label theScore;

        public AlexandruP()
        {
            mainImage = new Image
            {
                Source = GetPicture("simon.png", "http://i.imgur.com/GbBed3s.png")
            };


            var imageRec = new TapGestureRecognizer();
            imageRec.Tapped += (s, e) =>
            {
                // handle the tap
                if (theCommand.Text.Equals("Touch the image!"))
                {
                    DoOk();
                }
                else
                {
                    DoWrong();
                }
            };

            mainImage.GestureRecognizers.Add(imageRec);

            Button clickMe = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                BorderColor = Color.FromHex("102B3F"),
                BorderRadius = 30,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromHex("102B3F"),
                TextColor = Color.FromHex("FFFAFF"),
                Text = "I am the button, you may click me!"
            };
            clickMe.Clicked += IWasClicked;

            theCommand = new Label
            {
                TextColor = Color.FromHex("00090C"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = "Let the games Begin!"
            };


            var commandRec = new TapGestureRecognizer();
            commandRec.Tapped += (s, e) =>
            {
                // handle the tap
                if (theCommand.Text.Equals("Touch the text!"))
                {
                    DoOk();
                }
                else
                {
                    DoWrong();
                }
            };

            theCommand.GestureRecognizers.Add(commandRec);

            theScore = new Label
            {
                TextColor = Color.FromHex("00090C"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = score.ToString()
            };


            var scoreRec = new TapGestureRecognizer();
            scoreRec.Tapped += (s, e) =>
            {
                // handle the tap
                if (theCommand.Text.Equals("Touch the score!"))
                {
                    DoOk();
                }
                else
                {
                    DoWrong();
                }
            };

            theScore.GestureRecognizers.Add(scoreRec);

            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 20,
                Children = {
                        mainImage,
                        theCommand,
                        clickMe,
                        theScore
                    }
            };
        }

        private void DoWrong()
        {
            if (score > 0)
            {
                score = 0;
                theScore.Text = score.ToString();
                gotOk = false;
                mainImage.Source = GetPicture("no.png", "http://i.imgur.com/hPENEYe.png");
            }

            theCommand.Text = DoRandomSimon();
        }

        private void DoOk()
        {
            if (score == 0)
            {
                gotOk = false;
                mainImage.Source = GetPicture("ok.png", "http://i.imgur.com/tsGKc4L.png");
            }
            score++;
            theScore.Text = score.ToString();
            theCommand.Text = DoRandomSimon();
        }

        private ImageSource GetPicture(string imageName, string URL)
        {
            ImageSource fromFile = ImageSource.FromFile(imageName);

            if (fromFile != null)
            {
                return fromFile;
            }

            return ImageSource.FromUri(new Uri(URL));
        }

        private string DoRandomSimon()
        {
            switch (RandomCommand())
            {

                case 0:
                    {
                        return "Touch the image!";
                    }

                case 1:
                    {
                        return "Press the button!";
                    }

                case 2:
                    {
                        return "Touch the text!";
                    }

                default:
                    {
                        return "Touch the score!";
                    }
            }
        }

        private int RandomCommand()
        {
            return ((new Random()).Next(0, 5));
        }

        private void IWasClicked(object sender, EventArgs e)
        {
            if (theCommand.Text.Equals("Press the button!") || gotOk)
            {
                DoOk();
            }
            else
            {
                DoWrong();
            }
        }
    }
}
