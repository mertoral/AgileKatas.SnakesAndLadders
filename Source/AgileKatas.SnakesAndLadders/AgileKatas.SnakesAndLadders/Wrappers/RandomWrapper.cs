using System;
using System.Collections.Generic;
using System.Text;

namespace AgileKatas.SnakesAndLadders.Wrappers
{
    public class RandomWrapper : IRandomWrapper
    {
        private readonly Random _random = new Random();

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
