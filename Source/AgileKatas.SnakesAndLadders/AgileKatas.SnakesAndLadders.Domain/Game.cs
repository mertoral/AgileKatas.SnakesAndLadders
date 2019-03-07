using System.Linq;
using AgileKatas.SnakesAndLadders.Domain.Boards;
using AgileKatas.SnakesAndLadders.Domain.Dice;

namespace AgileKatas.SnakesAndLadders.Domain
{
    public class Game : IGame
    {
        private readonly IBoardFactory _boardFactory;
        private Board _board;
        private readonly IDie _die;
        private readonly IGameSettings _gameSettings;

        public Board Board => _board;

        public Game(IBoardFactory boardFactory, IDie die, IGameSettings gameSettings)
        {
            _boardFactory = boardFactory;
            _die = die;
            _gameSettings = gameSettings;
        }
        
        public Board Start()
        {
            _board = _boardFactory.Create();
            return _board;
        }

        public ResultOfRollingDie RollDie(int player)
        {
            if (_board.Tokens.First().Player == player)
            {
                int moves = _die.Roll();
                _board.Tokens.First().RemainingMoves = moves;
                return new ResultOfRollingDie(player, moves);
            }
            return new ResultOfRollingDie(player, 0);
        }

        public ResultOfMovingToken MoveToken(int player)
        {
            if (Board.Tokens.First().Player != player)
            {
                return new ResultOfMovingToken(player, 0, 0, false);
            }

            Token token = Board.Tokens.First(x => x.Player == player);
            token.Move();

            if (Board.Ladders.ContainsKey(token.CurrentSquare))
            {
                return new ResultOfMovingToken(
                    player, 
                    token.CurrentSquare, 
                    Board.Ladders[token.CurrentSquare] - token.CurrentSquare,
                    token.CurrentSquare >= _gameSettings.SquaresOnBoard
                    );
            }

            if (Board.Snakes.ContainsKey(token.CurrentSquare))
            {
                return new ResultOfMovingToken(
                    player,
                    token.CurrentSquare,
                    token.CurrentSquare -Board.Snakes[token.CurrentSquare],
                    token.CurrentSquare >= _gameSettings.SquaresOnBoard);
            }

            Board.Tokens.Enqueue(Board.Tokens.Dequeue());

            return new ResultOfMovingToken(player, 0, token.CurrentSquare, token.CurrentSquare >= _gameSettings.SquaresOnBoard);
        }
    }
}
