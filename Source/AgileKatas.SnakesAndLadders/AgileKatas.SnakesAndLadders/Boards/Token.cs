namespace AgileKatas.SnakesAndLadders.Boards
{
    public class Token
    {
        private int _currentSquare;
        public int Player { get; }

        public int RemainingMoves { get; set; } = 0;

        public Token(int player, int startAt)
        {
            Player = player;
            _currentSquare = startAt;
        }

        public int CurrentSquare => _currentSquare;

        public void Move()
        {
            _currentSquare = CurrentSquare + RemainingMoves;
        }
    }
}