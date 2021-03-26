using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using rps_game.Interface;

namespace rps_game.Class
{
    public class Round: IRound
    {
        private IRoundService _roundService;
        private IPlayer[] _players;      

        private int winner = -1;
        private int _roundNo;

        public Round(IPlayer[] players, 
                     IRoundService roundService,
                     int roundNo)
        {
            _roundService = roundService;
            _players = players;
            _roundNo = roundNo;
        }
        
        public int Play()
        {
            Console.WriteLine();
            Console.WriteLine($"Round {_roundNo} starts");

            winner = _roundService.Go(_players);

            Console.WriteLine();

            if (winner == -1)
                Console.WriteLine($"Round {_roundNo} winner: draw");
            else
                Console.WriteLine($"Round {_roundNo} winner: {_players[winner].Name}");

            return winner;
        }
    }
}
