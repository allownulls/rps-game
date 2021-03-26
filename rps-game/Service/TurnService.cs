using System;
using System.Threading;
using rps_game.Interface;
using rps_game.Enum;

namespace rps_game.Service
{
    public class TurnService: ITurnService
    {
        IMessageService _messageService;
        
        private Random rand = new Random();
        
        public TurnService(IMessageService messageService) => _messageService = messageService;

        public int MakeTurn(IPlayer player)
        {
            int choice = 0;

            _messageService.WritePlayerTurn(player.Name);

            if (player.Type == PlayerType.Computer)
            {
                choice = MakeComputerTurn();
            }

            if (player.Type == PlayerType.Human)
            {
                choice = MakeHumanTurn();
            }

            _messageService.WritePlayerChoice(player.Name, ((Shape)choice).ToString());

            return choice;
        }

        private int MakeHumanTurn()
        {            
            string input;
            Shape choice = Shape.None;

            do
            {
                input = _messageService.ReadPlayerChoice();

                if (int.TryParse(input, out var i))
                {
                    choice = (Shape)System.Enum.ToObject(typeof(Shape), i);
                }
                else if (System.Enum.IsDefined(typeof(Shape), input))
                {
                    choice = (Shape)System.Enum.Parse(typeof(Shape), input);
                }
            } while (choice == Shape.None);                                        

            return (int)choice;
        }

        private int MakeComputerTurn()
        {            
            Thread.Sleep(2000);

            Shape choice = (Shape)(rand.Next(3) + 1);

            return (int)choice;
        }
    }
}
