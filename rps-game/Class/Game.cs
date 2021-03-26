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

            players = new IPlayer[noOfPlayers].Select((e, i) => e = _playerService.Create(i+1)).ToArray();                       
            rounds = (new Round[noOfRounds]).Select((e, i) => e = new Round(players, _roundService, i+1)).ToArray();
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
