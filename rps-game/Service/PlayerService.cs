using System;
using rps_game.Interface;
using rps_game.Enum;
using rps_game.Class;

namespace rps_game.Service
{
    public class PlayerService: IPlayerService
    {
        ITurnService _turnService;
        IMessageService _messageService;
        public PlayerService(ITurnService turnService, IMessageService messageService)
        {
            _turnService = turnService;
            _messageService = messageService;
        }

        private PlayerType SelectType(int No)
        {          
            string input;
            PlayerType type = PlayerType.None;

            do
            {
                input = _messageService.ReadPlayerType(No);

                if (int.TryParse(input, out var i))
                {
                    type = (PlayerType)System.Enum.ToObject(typeof(PlayerType), i);                    
                }
                else if (System.Enum.IsDefined(typeof(PlayerType), input))
                {
                    type = (PlayerType)System.Enum.Parse(typeof(PlayerType), input);                    
                }

            } while (type == PlayerType.None);

            _messageService.WritePlayerType(type.ToString());

            return type;
        }

        public IPlayer Create(int No)
        {
            var type = SelectType(No);

            if (type == PlayerType.Human)
            {
                string input;
                do
                {
                    input = _messageService.ReadPlayerName(No);
                } while (String.IsNullOrEmpty(input) || input.Length > 10);

                return new Human(_turnService) { Name = input};
            }

            if (type == PlayerType.Computer)
            {
                return new Computer(_turnService) { Name = "Computer"};
            }

            return null;
        }
    }
}
