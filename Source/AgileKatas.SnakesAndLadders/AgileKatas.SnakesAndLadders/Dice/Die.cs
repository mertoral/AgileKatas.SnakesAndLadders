using System;

namespace AgileKatas.SnakesAndLadders.Dice
{
    class Die : IDie
    {
        private readonly Random _random = new Random();

        public int Roll()
        {
            return _random.Next(6) + 1;
        }
    }
}
