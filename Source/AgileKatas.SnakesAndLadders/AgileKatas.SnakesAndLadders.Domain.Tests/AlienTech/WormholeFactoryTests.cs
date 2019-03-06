using System;
using System.Collections.Generic;
using System.Text;
using AgileKatas.SnakesAndLadders.AlienTech;
using AgileKatas.SnakesAndLadders.Wrappers;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AgileKatas.SnakesAndLadders.Tests.AlienTech
{
    [TestFixture]
    public class WormholeFactoryTests
    {
        private IGameSettings _gameSettings; //= Substitute.For<IGameSettings>()
        private IWormholeValidator _wormholeValidator; //= Substitute.For<IGameSettings>()
        private IRandomWrapper _randomWrapper; //= Substitute.For<IGameSettings>()

        [SetUp]
        public void Setup()
        {
            _gameSettings = Substitute.For<IGameSettings>();
            _gameSettings.MaximumTransporterRange.Returns(5);

            _wormholeValidator = Substitute.For<IWormholeValidator>();
            _wormholeValidator.Validate(Arg.Any<int>(), Arg.Any<Wormhole>()).Returns(true);
            _randomWrapper = Substitute.For<IRandomWrapper>();
            _randomWrapper.Next(1, _gameSettings.MaximumTransporterRange).Returns(3);
        }


        [Test]
        public void Create_WormholeHasCorrectTarget()
        {
            new WormholeFactory(_gameSettings, _wormholeValidator, _randomWrapper)
                .Create(1, WormholeDirection.Forward)
                .Target.Should().Be(4);
        }

         
    }
}
