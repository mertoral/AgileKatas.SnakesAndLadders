namespace AgileKatas.SnakesAndLadders.AlienTech
{
    public class Wormhole
    {
        private readonly int _source;
        private readonly WormholeDirection _direction;
        private readonly int _range;

        public Wormhole(int source, WormholeDirection direction, int range)
        {
            _source = source;
            _direction = direction;
            _range = range;
        }

        public int Target
        {
            get
            {
                if (this._direction == WormholeDirection.Forward)
                {
                    return _source + this._range;
                }

                return _source - this._range;
            }    
        }
    }
}