using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileKatas.SnakesAndLadders.Domain.AlienTech;
using AgileKatas.SnakesAndLadders.Domain.Boards;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AgileKatas.SnakesAndLadders.Domain.Tests.Boards
{
    [TestFixture]
    public class BoardFactoryTests
    {
        private IGameSettings _gameSettings;
        private IWormholeFactory _wormholeFactory = Substitute.For<IWormholeFactory>();
        private BoardFactory _boardFactory;
        private Board _board;

        [SetUp]
        public void Setup()
        {
            _gameSettings = Substitute.For<IGameSettings>();
            _gameSettings.PlayerCount.Returns(4);
            _gameSettings.SquaresOnBoard.Returns(100);
            _gameSettings.SnakeCount.Returns(3);
            _gameSettings.LadderCount.Returns(4);

            _wormholeFactory = Substitute.For<IWormholeFactory>();
            _wormholeFactory.Create(Arg.Any<int>(), WormholeDirection.Forward)
                .Returns(new Wormhole(1, WormholeDirection.Forward, 2));
            _wormholeFactory.Create(Arg.Any<int>(), WormholeDirection.BackWard)
                .Returns(new Wormhole(1, WormholeDirection.BackWard, 2));

            _boardFactory = new  BoardFactory(_gameSettings, _wormholeFactory);
            _board = _boardFactory.Create();
        }

        [Test]
        public void BoardHasTokens()
        {
            _board.Tokens.Any()
                .Should().BeTrue();
        }

        [Test]
        public void BoardHasSnakes()
        {
            _board.Snakes.Count().Should().Be(3);
        }

        [Test]
        public void BoardHasLadders()
        {
            _board.Ladders.Count.Should().Be(4);
        }
    }
}



