using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rps_game.Service;
using rps_game.Interface;
using rps_game.Enum;
using rps_game.Class;
using Moq;


namespace rps_test
{
    [TestClass]
    public class ResultServiceTest
    {
        [TestMethod]
        public void GetRoundWinner()
        {
            var resultsService = new ResultsService();

            int[,] ans = new int[3, 3];

            ans[0, 0] = -1;
            ans[0, 1] = 1;
            ans[0, 2] = 0;
            ans[1, 0] = 0;
            ans[1, 1] = -1;
            ans[1, 2] = 1;
            ans[2, 0] = 1;
            ans[2, 1] = 0;
            ans[2, 2] = -1;

            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                {
                    var result = new[] { i + 1, j + 1 };
                    Assert.IsTrue(resultsService.GetRoundWinner(result) == ans[i, j]);
                }
        }




        [TestMethod]
        public void GetGameWinner()
        {
            var resultsService = new ResultsService();

            List<Line> ans = new List<Line>()
            {
                new Line(){ RoundsResult = new int[] { 0,0,0}, Answer = 0 },
                new Line(){ RoundsResult = new int[] { 0,0,1}, Answer = 0 },
                new Line(){ RoundsResult = new int[] { 0,1,0}, Answer = 0 },
                new Line(){ RoundsResult = new int[] { 0,1,1}, Answer = 1 },
                new Line(){ RoundsResult = new int[] { 1,0,0}, Answer = 0 },
                new Line(){ RoundsResult = new int[] { 1,0,1}, Answer = 1 },
                new Line(){ RoundsResult = new int[] { 1,1,0}, Answer = 1 },
                new Line(){ RoundsResult = new int[] { 1,1,1}, Answer = 1 },
            };

            for (var i = 0; i < ans.Count; i++)
            {
                Assert.IsTrue(resultsService.GetGameWinner(ans[i].RoundsResult) == ans[i].Answer);            
            }
        }
    }
    public class Line
    {
        public int? Answer { get; set; }
        public int[] RoundsResult { get; set; }
    }
}