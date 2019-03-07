using System.Linq;
using AgileKatas.SnakesAndLadders.Api.ViewModels;
using AgileKatas.SnakesAndLadders.Domain;
using AgileKatas.SnakesAndLadders.Domain.Boards;
using AgileKatas.SnakesAndLadders.Util;

namespace AgileKatas.SnakesAndLadders.Api.Mappers
{
    public class BoardToViewModelMapper : IMapper<Board, BoardViewModel>
    {
        private readonly IGameSettings _gameSettings;

        public BoardToViewModelMapper(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public BoardViewModel Map(Board mapThis)
        {
            BoardViewModel boardViewModel = new BoardViewModel();
            boardViewModel.LadderViewModels.AddRange(mapThis.Ladders.Select(x => new LadderViewModel() { CurrentSquare = x.Key, TargetSquare = x.Value }));
            boardViewModel.SnakeViewModels.AddRange(mapThis.Snakes.Select(x => new SnakeViewModel() { CurrentSquare = x.Key, TargetSquare = x.Value }));
            boardViewModel.PlayerViewModels.AddRange(mapThis.Tokens.Select(x => new PlayerViewModel(){CurrentSquare = x.CurrentSquare, Number = x.Player, RemainingMoves = x.RemainingMoves}));
            boardViewModel.Squares = _gameSettings.SquaresOnBoard;

            return boardViewModel;
        }
    }
}
