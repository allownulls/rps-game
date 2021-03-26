using System;
using System.Collections.Generic;
using System.Text;
using rps_game.Interface;
using rps_game.Enum;

namespace rps_game.Class
{
    public class Human : IPlayer
    {
        ITurnService _turnService;
        public Human(ITurnService turnService) => _turnService = turnService;
        public PlayerType Type { get { return PlayerType.Human; } }
        public string Name { get; set; }
        public int MakeTurn() => _turnService.MakeTurn(this);
    }
}
