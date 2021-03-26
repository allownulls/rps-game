using System;
using System.Collections.Generic;
using System.Text;
using rps_game.Interface;
using rps_game.Enum;

namespace rps_game.Class
{
    public class Computer: IPlayer
    {
        ITurnService _turnService;
        public Computer(ITurnService turnService) => _turnService = turnService;        
        public PlayerType Type { get { return PlayerType.Computer; } }
        public string Name { get; set; }
        public int MakeTurn() => _turnService.MakeTurn(this);
    }
}
