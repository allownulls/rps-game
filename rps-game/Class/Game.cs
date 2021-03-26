using System;
using System.Collections.Generic;
using System.Text;
using rps_game.Interface;
using rps_game.Enum;
using System.Linq;


namespace rps_game.Class
{
    public class Game
    {
        const int noOfRounds = 3;
        const int noOfPlayers = 2;

        IRound[] rounds;
        IPlayer[] players;

        IResultsService _resultsService;
        IRoundService _roundService;
        IPlayerService _playerService;
        IMessageService _messageService;

        public Game(IResultsService resultsService, 
                    IRoundService roundService,                    
                    IPlayerService playerService,
                    IMessageService messageService)
        {
            _resultsService = resultsService;
            _roundService = roundService;            
            _playerService = playerService;
            _messageService = messageService;

            GeneratePlayers();
            rounds = (new Round[noOfRounds]).Select((e, i) => e = new Round(players, _roundService, i+1)).ToArray();
        }

        private void GeneratePlayers()
        {
            players = new IPlayer[noOfPlayers];            

            for (var i = 0; i < noOfPlayers; i++)
            {
                IPlayer p = null;
                do
                {
                    if (p != null && p.Type == PlayerType.Human)
                        _messageService.WritePlayerExists(p.Name);
                        
                    p = _playerService.Create(i + 1);                    
                }
                while (players.Any(e => e?.Name == p?.Name));

                players[i] = p;

                _messageService.WritePlayer(p.Type.ToString(), p.Name);
            }                                                                
        }

        public void Play()
        {
            int? winner = _resultsService.GetGameWinner(rounds.Select(e => e.Play()).ToArray());
            
            if (winner != null)
                _messageService.WriteGameWinner(players[winner.Value].Name);
            else
                _messageService.WriteGameWinner();
        }
    }
}
