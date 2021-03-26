using Microsoft.VisualStudio.TestTools.UnitTesting;
using rps_game.Service;
using rps_game.Interface;
using rps_game.Enum;
using rps_game.Class;
using Moq;


namespace rps_test
{
    [TestClass]
    public class PlayerServiceTest
    {
        [TestMethod]
        public void Create()
        {
            var player = new Mock<IPlayer>();

            string name = "Player 1";

            var turnService = new Mock<ITurnService>();
            turnService.Setup(e => e.MakeTurn(player.Object)).Returns(1);

            var messageService = new Mock<IMessageService>();
            messageService.Setup(e => e.ReadPlayerType(0)).Returns("1");
            messageService.Setup(e => e.ReadPlayerType(1)).Returns("2");
            messageService.Setup(e => e.ReadPlayerName(0)).Returns(name);            

            PlayerService playerService = new PlayerService(turnService.Object, messageService.Object);

            var player1 = playerService.Create(0);
            var player2 = playerService.Create(1);

            Assert.IsTrue(player1 != null);
            Assert.IsTrue(player1.Name == name);
            Assert.IsTrue(player1.Type == PlayerType.Human);

            Assert.IsTrue(player2 != null);
            Assert.IsTrue(player2.Type == PlayerType.Computer);            
        }        
    }
}


