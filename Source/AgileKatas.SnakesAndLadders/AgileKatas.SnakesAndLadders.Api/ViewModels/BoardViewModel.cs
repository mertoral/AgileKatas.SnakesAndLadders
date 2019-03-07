using System.Collections.Generic;

namespace AgileKatas.SnakesAndLadders.Api.ViewModels
{
    public class BoardViewModel
    {
        public int Squares { get; set; }
        public List<PlayerViewModel> PlayerViewModels  => new List<PlayerViewModel>();
        public List<LadderViewModel> LadderViewModels => new List<LadderViewModel>();
        public List<SnakeViewModel> SnakeViewModels => new List<SnakeViewModel>();
    }

    public class PlayerViewModel
    {
        public int Number { get; set; }
        public int CurrentSquare { get; set; }
    }
}
