using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileKatas.SnakesAndLadders.Domain.Boards;
using AgileKatas.SnakesAndLadders.Domain.Dice;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AgileKatas.SnakesAndLadders.Domain.Tests
{
    [TestFixture]
    public class GameTests
    {
        private readonly IBoardFactory _boardFactory = Substitute.For<IBoardFactory>();
        private readonly IDie _die = Substitute.For<IDie>();
        private readonly IGameSettings _gameSettings = Substitute.For<IGameSettings>();
        private Board _board;

        [SetUp]
        public void Setup()
        {
            _die.Roll().Returns(5);
            _gameSettings.SquaresOnBoard = 100;
            _board = new Board();
            _board.Tokens.Enqueue(new Token(1, 1));
            _board.Tokens.Enqueue(new Token(2, 1));
            _boardFactory.Create().Returns(_board);
        }
        
        [Test]
        public void RollDie_NotPlayersTurn_ResultHasZeroMoves()
        {
            Game game = new Game(_boardFactory, _die, _gameSettings);
            game.Start();

            game.RollDie(2).RemainingMoves.Should()
                .Be(0, "Because it is not player 2's turn");
        }

        [Test]
        public void RollDie_NotPlayersTurn_NoMovesAddedToPlayer()
        {
            Game game = new Game(_boardFactory, _die, _gameSettings);
            game.Start();

            game.RollDie(2);
            _board.Tokens.First(x => x.Player == 2).RemainingMoves.Should().Be(0, "Because if you roll a die before it's your turn you don't get any moves");
        }

        [Test]
        public void RollDie_NotPlayersTurn_ResultHasCorrectPlayer()
        {
            Game game = new Game(_boardFactory, _die, _gameSettings);
            game.Start();

            game.RollDie(2).Player.Should()
                .Be(2, "Because player 2 rolled the die");
        }

        [Test]
        public void RollDie_PlayersTurn_ResultHasCorrectMoves()
        {
            Game game = new Game(_boardFactory, _die, _gameSettings);
            game.Start();

            game.RollDie(1).RemainingMoves.Should()
                .Be(5, "Because it is not player 1's turn");
        }

        [Test]
        public void RollDie_PlayersTurn_MovesAddedToPlayer()
        {
            Game game = new Game(_boardFactory, _die, _gameSettings);
            game.Start();

            game.RollDie(1);
            _board.Tokens.First(x => x.Player == 1).RemainingMoves.Should().Be(5, "Because if you roll a die when it's your turn you get the moves ");
        }


        [Test]
        public void RollDie_PlayersTurn_ResultHasCorrectPlayer()
        {
            Game game = new Game(_boardFactory, _die, _gameSettings);
            game.Start();

            game.RollDie(1).Player.Should()
                .Be(1, "Because player 2 rolled the die");
        }
    }
}
