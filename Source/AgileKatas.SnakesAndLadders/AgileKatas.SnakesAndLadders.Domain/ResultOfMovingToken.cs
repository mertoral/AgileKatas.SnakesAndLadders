namespace AgileKatas.SnakesAndLadders.Domain
{
    public class ResultOfMovingToken
    {

        public int Player { get; }
        public int CurrentSquare { get; }
        public int RemainingMoves { get; }
        public bool GameWon { get; }
        public ResultOfMovingToken(int player, int currentSquare, int remainingMoves, bool gameWon)
        {
            GameWon = gameWon;
            CurrentSquare = currentSquare;
            Player = player;
            RemainingMoves = remainingMoves;
        }
        
    }
}