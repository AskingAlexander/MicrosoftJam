using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MicrosoftJam.GamePages.VladO
{
    public class LightsOut
    {
        private int size = 5;
        private int[,] board { get; set; }
        public const int maxMoves = 20;
        public const int minMoves = 5;
        public int moves;
        public int startScore;

        public LightsOut(int size)
        {
            this.size = size;
            board = new int[size, size];
            startScore = size * size;
        }

        public int init()
        {
            moves = minMoves + (new Random()).Next(maxMoves - minMoves + 1);
            for (int i = 0; i < moves; i++)
            {
                int row = (new Random()).Next(size);
                int col = (new Random()).Next(size);
                change(row, col);
            }

            return startScore + moves;
        }

        public void change(int row, int col)
        {
            changeOne(row, col);
            changeOne(row - 1, col);
            changeOne(row, col + 1);
            changeOne(row + 1, col);
            changeOne(row, col - 1);
        }

        private void changeOne(int row, int col)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
                board[row, col] = (board[row, col] + 1) % 2;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    result += board[i, j] + " ";
                result += "\n";
            }
            return result;
        }

        public void updateBoard(Button[,] buttons)
        {
            for (int row = 0; row < size; row++)
                for (int col = 0; col < size; col++)
                    changeButton(buttons[row, col], row, col);
        }

        private void changeButton(Button button, int row, int col)
        {
            if (board[row, col] == 1)
            {
                button.BackgroundColor = Color.White;
                button.TextColor = Color.White;
            }
            else
            {
                button.BackgroundColor = Color.FromHex("#dddddd");
                button.TextColor = Color.FromHex("#dddddd");
            }           
        }
       
    }
}
