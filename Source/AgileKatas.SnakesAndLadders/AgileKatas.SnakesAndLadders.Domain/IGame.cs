using AgileKatas.SnakesAndLadders.Domain.Boards;

namespace AgileKatas.SnakesAndLadders.Domain
{
    public interface IGame
    {
        Board Start();
        ResultOfRollingDie RollDie(int player);
        ResultOfMovingToken MoveToken(int player);
    }
}