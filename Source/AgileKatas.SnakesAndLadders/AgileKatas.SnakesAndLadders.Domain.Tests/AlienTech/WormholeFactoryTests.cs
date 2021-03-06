﻿using AgileKatas.SnakesAndLadders.Domain.AlienTech;
using AgileKatas.SnakesAndLadders.Domain.Wrappers;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AgileKatas.SnakesAndLadders.Domain.Tests.AlienTech
{
    [TestFixture]
    public class WormholeFactoryTests
    {
        private IGameSettings _gameSettings; 
        private IWormholeValidator _wormholeValidator; 
        private IRandomWrapper _randomWrapper; 

        [SetUp]
        public void Setup()
        {
            _gameSettings = Substitute.For<IGameSettings>();
            _gameSettings.MaximumWormHoleRange.Returns(5);

            _wormholeValidator = Substitute.For<IWormholeValidator>();
            _wormholeValidator.Validate(Arg.Any<Wormhole>()).Returns(true);
            _randomWrapper = Substitute.For<IRandomWrapper>();
            _randomWrapper.Next(1, _gameSettings.MaximumWormHoleRange).Returns(3);
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
