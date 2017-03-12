using MicrosoftJam.UtilityClasses;
using System;
using Xamarin.Forms;

namespace MicrosoftJam.GamePages.VladO
{
    class VladO : ContentPage
    {
        private const int size = 5;
        private const int mainLayoutPadding = 24;
        private LightsOut lightsOut = new LightsOut(size);
        private Button[,] buttons;
        private int score;
        private bool canPlay;
        private Label scoreLabel;
        private Label title;

        public VladO()
        {
            StackLayout mainLayout = new StackLayout
            {
                Padding = mainLayoutPadding
            };

            title = new Label
            {
                Text = "LIGHTOUT",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            mainLayout.Children.Add(title);

            scoreLabel = new Label
            {
                Text = score.ToString(),
                HorizontalOptions = LayoutOptions.Center
            };
            mainLayout.Children.Add(scoreLabel);

            RowDefinitionCollection boardRows = new RowDefinitionCollection();
            ColumnDefinitionCollection boardCols = new ColumnDefinitionCollection();
            for (int i = 0; i < size; i++)
            {
                boardRows.Add(new RowDefinition
                {
                    Height = new GridLength(1, GridUnitType.Star),
                });
                boardCols.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
            }

            Grid board = new Grid
            {
                RowDefinitions = boardRows,
                ColumnDefinitions = boardCols,
                HeightRequest = Application.Current.MainPage.Width - mainLayoutPadding,
                RowSpacing = 0,
                ColumnSpacing = 0
            };

            buttons = new Button[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Text = i + " " + j,
                        Margin = new Thickness(-4, -6, -4, -6),
                        TextColor = Color.FromHex("#dddddd"),
                        BackgroundColor = Color.FromHex("#dddddd"),
                    };
                    buttons[i, j].Clicked += buttonClick;
                    board.Children.Add(buttons[i, j], j, i);
                }
            mainLayout.Children.Add(board);


            Button playButton = new Button
            {
                Text = "Play"
            };
            playButton.Clicked += PlayButton_Clicked;
            mainLayout.Children.Add(playButton);
            
            this.Content = mainLayout;         
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            score = lightsOut.init();
            lightsOut.updateBoard(buttons);
            scoreLabel.Text = score.ToString();        
            canPlay = true;

            if (((Button)sender).Text.Equals("Play"))
            {
                ((Button)sender).Text = "Replay";
            }
            else
            {
                title.Text = "LIGHTSOUT";
            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (canPlay)
            {
                String[] tokens = ((Button)sender).Text.Split(' ');
                int i = Int32.Parse(tokens[0]);
                int j = Int32.Parse(tokens[1]);

                lightsOut.change(i, j);
                lightsOut.updateBoard(buttons);

                score--;
                scoreLabel.Text = score.ToString();

                if (score > 0)
                {
                    if (hasWon())
                    {
                        canPlay = false;
                        title.Text = "YOU WON";
                        ScoreRelated.totalScore += score / 100d;
                        ScoreRelated.UpdateScore();
                    }
                }
                else
                {
                    title.Text = "YOU'VE LOST";
                }
            }
        }
        
        private bool hasWon()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (buttons[i, j].BackgroundColor == Color.White)
                    {
                        return false;
                    }

            return true;
        }
    }

}
