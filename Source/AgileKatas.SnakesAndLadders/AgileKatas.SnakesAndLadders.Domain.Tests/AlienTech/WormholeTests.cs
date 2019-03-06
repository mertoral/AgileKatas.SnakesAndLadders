using System;
using System.Collections.Generic;
using System.Text;
using AgileKatas.SnakesAndLadders.Domain.AlienTech;
using FluentAssertions;
using NUnit.Framework;

namespace AgileKatas.SnakesAndLadders.Tests.AlienTech
{
    [TestFixture]
    public class WormholeTests
    {
        [Test]
        public void Target_DirectionForward_ReturnsSourcePlusRange()
        {
            new Wormhole(1, WormholeDirection.Forward, 5).Target.Should()
                .Be(6, "Be cause this is a ladder from square 1 to 6 ");
        }

        [Test]
        public void Target_DirectionBackward_ReturnsSourceMinusRange()
        {
            new Wormhole(10, WormholeDirection.BackWard, 5).Target.Should()
                .Be(5, "Be cause this is a ladder from square 10 to 5 ");
        }
    }
}

