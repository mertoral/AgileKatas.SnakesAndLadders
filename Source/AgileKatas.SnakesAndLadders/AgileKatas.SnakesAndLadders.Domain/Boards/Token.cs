namespace AgileKatas.SnakesAndLadders.Domain.Boards
{
    public class Token
    {
        public int CurrentSquare { get; private set; }
        public int Player { get; }
        
        public int RemainingMoves { get; set; } = 0;

        public Token(int player, int startAt)
        {
            Player = player;
            CurrentSquare = startAt;
        }
        
        public void Move()
        {
            CurrentSquare = CurrentSquare + RemainingMoves;
        }
    }
}