namespace AgileKatas.SnakesAndLadders.AlienTech
{
    public interface IWormholeFactory
    {
        Wormhole Create(int square, WormholeDirection direction);
    }
}