namespace AgileKatas.SnakesAndLadders.Domain.AlienTech
{
    public class WormholeValidator : IWormholeValidator
    {
        private readonly IGameSettings _gameSettings;

        public WormholeValidator(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public bool Validate(int square, Wormhole wormhole)
        {
            return
                square + wormhole.Target <= _gameSettings.SquaresOnBoard &&
                square + wormhole.Target >= 1;
        }
    }
}