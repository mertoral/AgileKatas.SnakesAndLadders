using System;
using System.Collections.Generic;
using AgileKatas.SnakesAndLadders.Domain.AlienTech;

namespace AgileKatas.SnakesAndLadders.Domain.Boards
{
    public class BoardFactory : IBoardFactory
    {
        private readonly IGameSettings _gameSettings;
        private IWormholeFactory _wormholeFactory;
        
        public BoardFactory(IGameSettings gameSettings, IWormholeFactory wormholeFactory)
        {
            _gameSettings = gameSettings;
            _wormholeFactory = wormholeFactory;
        }

        public Board Create()
        {
            Board board = new Board();
            InitTokens(board);

            return board;
        }

        private void InitTokens(Board board)
        {
            List<Token> tokens = new List<Token>();
            
            for (int i = 1; i <= _gameSettings.PlayerCount; i++)
            {
                tokens.Add(new Token(i, _gameSettings.AllTokensStartOn));
            }

            Shuffle(tokens);
            tokens.ForEach(board.Tokens.Enqueue);
        }

        private void InitLadders(Board board)
        {
            for (int i = 1; i <= _gameSettings.LadderCount; i++)
            {
                int square = new Random(_gameSettings.SquaresOnBoard).Next();
                Wormhole wormhole = _wormholeFactory.Create(square, WormholeDirection.Forward);
                board.Ladders.Add(square, wormhole.Target);
            }
        }

        private void InitSnakes(Board board)
        {
            for (int i = 1; i <= _gameSettings.SnakeCount; i++)
            {
                int square = new Random(_gameSettings.SquaresOnBoard).Next();
                Wormhole wormhole = _wormholeFactory.Create(square, WormholeDirection.BackWard);
                board.Ladders.Add(square, wormhole.Target);
            }
        }

        private static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = new Random().Next(n + 1);
                T value = list[k]; 
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
