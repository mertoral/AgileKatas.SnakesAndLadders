namespace AgileKatas.SnakesAndLadders.Domain
{
    public interface IGame
    {
        void Start();
        ResultOfRollingDie RollDie(int player);
        ResultOfMovingToken MoveToken(int player);
    }
}