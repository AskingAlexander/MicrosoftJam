using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MicrosoftJam.UtilityClasses
{
    class ScoreRelated
    {
        public static double totalScore = 0;
        public static UInt64[] partialScores = new UInt64[3];

        public static void UpdateScore()
        {

            if (ScoreRelated.totalScore == 0)
            {
                string tempScore = DependencyService.Get<ISaveAndLoad>().LoadText("score.txt"); ;

                if (tempScore.Length > 0)
                {
                    ScoreRelated.totalScore = Double.Parse(tempScore);
                }
            }
            else
            {
                DependencyService.Get<ISaveAndLoad>().SaveText("score.txt", ScoreRelated.totalScore.ToString());
            }
        }
    }
}
