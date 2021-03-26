using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rps_game.Service;
using rps_game.Interface;
using rps_game.Enum;
using rps_game.Class;
using Moq;


namespace rps_test
{
    [TestClass]
    public class RoundServiceTest
    {
        [TestMethod]
        public void Go()
        {
            string name1 = "Player 1";
            string name2 = "Player 2";

            var messageService = new Mock<IMessageService>();            

            var turnService = new Mock<ITurnService>();            

            var resultsService = new ResultsService();
            var roundService = new RoundService(resultsService);

            IPlayer[] players = new IPlayer[2]
            {
                new Human(turnService.Object){ Name = name1 },
                new Human(turnService.Object){ Name = name2 }
            };

            for (var i = 0; i < 4; i++)
            {
                messageService.Setup(e => e.ReadPlayerChoice()).Returns(i.ToString());
                int result = roundService.Go(players);

                Assert.IsTrue(result == -1);
            }
        }        
    }
}