namespace AgileKatas.SnakesAndLadders.Domain.AlienTech
{
    public class WormholeValidator : IWormholeValidator
    {
        private readonly IGameSettings _gameSettings;

        public WormholeValidator(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public bool Validate(Wormhole wormhole)
        {
            return StaysWithinBoard(wormhole);
        }

        public bool StaysWithinBoard(Wormhole wormhole)
        {
            
            return
                wormhole.Target <= _gameSettings.SquaresOnBoard &&
                wormhole.Target >= 1;
        }
    }
}