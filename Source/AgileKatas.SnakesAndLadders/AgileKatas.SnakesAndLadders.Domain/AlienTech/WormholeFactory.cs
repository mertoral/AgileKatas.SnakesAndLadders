using System;
using AgileKatas.SnakesAndLadders.Domain.AlienTech;
using AgileKatas.SnakesAndLadders.Domain.Wrappers;

namespace AgileKatas.SnakesAndLadders.Domain.AlienTech
{
    public class WormholeFactory : IWormholeFactory
    {
        private readonly IGameSettings _gameSettings;
        private readonly IWormholeValidator _wormholeValidator;
        private readonly IRandomWrapper _randomWrapper;

        public WormholeFactory(IGameSettings gameSettings, IWormholeValidator wormholeValidator, IRandomWrapper randomWrapper)
        {
            _gameSettings = gameSettings;
            _wormholeValidator = wormholeValidator;
            _randomWrapper = randomWrapper;
        }
        
        public Wormhole Create(int square, WormholeDirection direction)
        {
            Wormhole wormhole;

            do
            {
                wormhole = new Wormhole(square, direction, _randomWrapper.Next(1, _gameSettings.MaximumTransporterRange));

            } while (!_wormholeValidator.Validate(square, wormhole));

            return wormhole;
        }
    }
}