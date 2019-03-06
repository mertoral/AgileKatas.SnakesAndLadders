namespace AgileKatas.SnakesAndLadders.Domain.AlienTech
{
    public interface IWormholeFactory
    {
        Wormhole Create(int square, WormholeDirection direction);
    }
}