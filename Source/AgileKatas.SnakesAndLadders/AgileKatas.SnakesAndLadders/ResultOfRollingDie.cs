namespace AgileKatas.SnakesAndLadders.Domain
{
    public class ResultOfRollingDie
    {
        public ResultOfRollingDie(int player, int remainingMoves)
        {
            Player = player;
            RemainingMoves = remainingMoves;
        }

        public int Player { get; }
        public int RemainingMoves { get; private set; }
    }
}