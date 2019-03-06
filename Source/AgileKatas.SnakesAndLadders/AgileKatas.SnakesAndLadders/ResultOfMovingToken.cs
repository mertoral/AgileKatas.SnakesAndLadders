namespace AgileKatas.SnakesAndLadders.Domain
{
    public class ResultOfMovingToken
    {

        public int Player { get; }
        public int RemainingMoves { get; }
        public bool GameWon { get; }
        public ResultOfMovingToken(int player, int remainingMoves, bool gameWon)
        {
            GameWon = gameWon;
            Player = player;
            RemainingMoves = remainingMoves;
        }
        
    }
}