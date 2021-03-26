using System.Linq;
using rps_game.Interface;

namespace rps_game.Service
{
    public class RoundService: IRoundService
    {
        IResultsService _resultsService;
        public RoundService(IResultsService resultsService) => _resultsService = resultsService;
        public int Go(IPlayer[] players) => _resultsService.GetRoundWinner(players.Select(e => e.MakeTurn()).ToArray());
    }
}
