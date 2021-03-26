using System;
using rps_game.Interface;
using System.Linq;

namespace rps_game.Service
{
    public class ResultsService: IResultsService
    {
        public int GetRoundWinner(int[] results)
        {
            int winner = -1;
            int[] score = new int[results.Length];

            var max = 0;

            for (var i = 0; i < results.Length; i++)
            {                
                for (var j = i + 1; j < results.Length; j++)
                {
                    if (i != j)
                        score[i] += CalcScore(results[i], results[j]);
                }

                max = Math.Max(max, score[i]);
            }

            if (score.Count(e => e == max) == 1)
                winner = Array.IndexOf(score, max);

            return winner;
        }

        private int CalcScore(int shapeOne, int shapeTwo)
        {
            if (shapeOne == 1)
            {
                if (shapeTwo == 1) return 0;
                if (shapeTwo == 2) return -1;
                if (shapeTwo == 3) return 1;
            }
            if (shapeOne == 2)
            {
                if (shapeTwo == 1) return 1;
                if (shapeTwo == 2) return 0;
                if (shapeTwo == 3) return -1;
            }
            if (shapeOne == 3)
            {
                if (shapeTwo == 1) return -1;
                if (shapeTwo == 2) return 1;
                if (shapeTwo == 3) return 0;
            }

            return 0;
        }

        public int? GetGameWinner(int[] results)
        {
            int? ret = null;

            if (results.Any(e => e >= 0)) // all rounds draws
            {
                var group = results.Where(e => e >= 0)
                                   .GroupBy(e => e)
                                   .Select(e => new { Key = e.Key, Values = e.Count()})
                                   .OrderByDescending(e => e.Values).ToList();

                bool draw = group.Count > 1 && group[0].Values == group[1].Values; // two winners - draw       

                return draw ? (int?)null : group.First().Key;
            }

            return ret;
        }
           
    }
}
