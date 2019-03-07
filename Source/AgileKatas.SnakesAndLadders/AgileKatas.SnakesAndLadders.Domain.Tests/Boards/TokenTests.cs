using System;
using System.Collections.Generic;
using System.Text;
using AgileKatas.SnakesAndLadders.Domain.Boards;
using FluentAssertions;
using NUnit.Framework;

namespace AgileKatas.SnakesAndLadders.Domain.Tests.Boards
{
    [TestFixture]
    public class TokenTests
    {
        [Test]
        public void NewToken_HasCorrectPlayer()
        {
            new Token(1, 2).Player.Should().Be(1);
        }

        [Test]
        public void NewToken_HasCorrectPosition()
        {
            new Token(1, 2).CurrentSquare.Should().Be(2);
        }

        [Test]
        public void Move_Current1_RemainingMoves5_CurrentIs6()
        {
           Token token = new Token(1, 2);
           token.RemainingMoves = 3;
           token.Move();
            token.CurrentSquare.Should().Be(5);

        }
    }
}
