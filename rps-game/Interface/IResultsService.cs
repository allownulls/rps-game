namespace rps_game.Interface
{
    public interface IResultsService
    {
        int GetRoundWinner(int[] results);

        int? GetGameWinner(int[] results);
    }
}
