using System;
using System.Collections.Generic;
using System.Text;
using AgileKatas.SnakesAndLadders.Domain.Boards;
using NSubstitute;

namespace AgileKatas.SnakesAndLadders.Domain.Tests
{
    public class GameTests
    {
        private IBoardFactory _boardFactory = Substitute.For<IBoardFactory>();
    }
}
