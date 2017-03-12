using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MicrosoftJam.GamePages.VladO
{
    class VladO : ContentPage
    {
        public VladO()
        {
            StackLayout mainLayout = new StackLayout
            {
                Padding = 24
            };

            const int size = 5;
            const int mainLayoutPadding = 24;

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

            Button[,] buttons = new Button[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Text = i + " " + j,
                        Margin = new Thickness(-4, -6, -4, -6),
                        TextColor = Color.FromHex("#dddddd"),
                        BackgroundColor = Color.FromHex("#dddddd")
                    };
                    board.Children.Add(buttons[i, j], j, i);
                }

            mainLayout.Children.Add(board);
            this.Content = mainLayout;

        }

        private void buttonClick(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Black;
        }
    }
}
