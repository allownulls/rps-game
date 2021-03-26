using rps_game.Enum;

namespace rps_game.Interface
{
    public interface IPlayer
    {
        PlayerType Type { get; }
        string Name { get; set; }

        int MakeTurn();
    }
}
