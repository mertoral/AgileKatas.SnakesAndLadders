using System;
using System.Collections.Generic;
using System.Text;
using AgileKatas.SnakesAndLadders.Domain.AlienTech;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AgileKatas.SnakesAndLadders.Domain.Tests.AlienTech
{
    [TestFixture]
    public class WormholeValidatorTests
    {
        private IGameSettings _gameSettings = Substitute.For<IGameSettings>();

        [Test]
        public void StaysWithinBoard_WarmHoleTargetOutOfBoard_ReturnsFalse()
        {
            _gameSettings.SquaresOnBoard.Returns(5);
            
            new WormholeValidator(_gameSettings)
                .StaysWithinBoard(new Wormhole(1, WormholeDirection.BackWard, 10))
                .Should().BeFalse();

            new WormholeValidator(_gameSettings)
                .StaysWithinBoard(new Wormhole(1, WormholeDirection.Forward, 10))
                .Should().BeFalse();
        }

        [Test]
        public void StaysWithinBoard_WarmHoleTargetWithinBoxBoard_ReturnsTrue()
        {
            _gameSettings.SquaresOnBoard.Returns(5);

            WormholeValidator validator = new WormholeValidator(_gameSettings);
            validator.StaysWithinBoard(new Wormhole(5, WormholeDirection.BackWard, 4))
                .Should().BeTrue();

            validator.StaysWithinBoard(new Wormhole(1, WormholeDirection.Forward, 4))
                .Should().BeTrue();
        }
    }
}
