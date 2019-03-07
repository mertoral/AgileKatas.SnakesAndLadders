using System.Linq;
using AgileKatas.SnakesAndLadders.Domain.Boards;
using AgileKatas.SnakesAndLadders.Domain.Dice;

namespace AgileKatas.SnakesAndLadders.Domain
{
    public class Game
    {
        private readonly IBoardFactory _boardFactory;
        private Board _board;
        private readonly IDie _die;
        private readonly IGameSettings _gameSettings;

        public Game(IBoardFactory boardFactory, IDie die, IGameSettings gameSettings)
        {
            _boardFactory = boardFactory;
            _die = die;
            _gameSettings = gameSettings;
        }

        public void Start()
        {
            _board = _boardFactory.Create();
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
            if (_board.Tokens.First().Player != player)
            {
                return new ResultOfMovingToken(player, 0, false);
            }

            Token token = _board.Tokens.First(x => x.Player == player);
            token.Move();

            if (_board.Ladders.ContainsKey(token.CurrentSquare))
            {
                return new ResultOfMovingToken(
                    player, 
                    _board.Ladders[token.CurrentSquare],
                    token.CurrentSquare >= _gameSettings.SquaresOnBoard
                    );
            }

            if (_board.Snakes.ContainsKey(token.CurrentSquare))
            {
                return new ResultOfMovingToken(
                    player, 
                    _board.Snakes[token.CurrentSquare],
                    token.CurrentSquare >= _gameSettings.SquaresOnBoard);
            }

            _board.Tokens.Enqueue(_board.Tokens.Dequeue());

            return new ResultOfMovingToken(player, 0, token.CurrentSquare >= _gameSettings.SquaresOnBoard);
        }
    }
}
