using System.Collections.Generic;

namespace AgileKatas.SnakesAndLadders.Boards
{
    public class Board
    {
        public readonly Queue<Token> Tokens = new Queue<Token>();
        public readonly Dictionary<int, int> Ladders = new Dictionary<int, int>();
        public readonly Dictionary<int, int> Snakes = new Dictionary<int, int>();
    }
}
