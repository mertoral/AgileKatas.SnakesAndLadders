using System;

namespace AgileKatas.SnakesAndLadders.Util
{
    public interface IMapper<in TSource, out TTarget>
    {
        TTarget Map(TSource mapThis);
    }
}
