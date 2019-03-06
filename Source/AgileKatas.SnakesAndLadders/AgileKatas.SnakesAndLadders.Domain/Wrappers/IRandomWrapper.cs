namespace AgileKatas.SnakesAndLadders.Domain.Wrappers
{
    public interface IRandomWrapper
    {
        int Next(int minValue, int maxValue);
    }
}