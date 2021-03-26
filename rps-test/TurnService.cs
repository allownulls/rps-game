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
    public class TurnServiceTest
    {
        [TestMethod]
        public void MakeTurn()
        {
            string name = "Player 1";

            var messageService = new Mock<IMessageService>();

            var turnService = new TurnService(messageService.Object);

            IPlayer player1 = new Human(turnService) { Name = name };
            IPlayer player2 = new Computer(turnService);
            
            for (var i = 1; i < 4; i++)
            {
                messageService.Setup(e => e.ReadPlayerChoice()).Returns(i.ToString());

                int choice1 = player1.MakeTurn();
                int choice2 = player2.MakeTurn();

                Assert.IsTrue(choice1 == i);
                Assert.IsTrue(new[] { 1, 2, 3 }.Contains(choice2));                
            }
        }
    }
}