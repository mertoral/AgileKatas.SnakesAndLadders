using System;
using System.Collections.Generic;
using System.Linq;
using AgileKatas.SnakesAndLadders.Domain.AlienTech;

namespace AgileKatas.SnakesAndLadders.Domain.Boards
{
    public class BoardFactory : IBoardFactory
    {
        private readonly IGameSettings _gameSettings;
        private readonly IWormholeFactory _wormholeFactory;
        
        public BoardFactory(IGameSettings gameSettings, IWormholeFactory wormholeFactory)
        {
            _gameSettings = gameSettings;
            _wormholeFactory = wormholeFactory;
        }

        public Board Create()
        {
            Board board = new Board();
            PlaceTokens(board);
            PlaceLadders(board);
            PlaceSnakes(board);

            return board;
        }

        private void PlaceTokens(Board board)
        {
            List<Token> tokens = new List<Token>();
            
            for (int i = 1; i <= _gameSettings.PlayerCount; i++)
            {
                tokens.Add(new Token(i, _gameSettings.AllTokensStartOn));
            }

            Shuffle(tokens);
            tokens.ForEach(board.Tokens.Enqueue);
        }

        private void PlaceLadders(Board board)
        {
            for (int i = 1; i <= _gameSettings.LadderCount; i++)
            {
                int square = GenerateSquare(board);

                Wormhole wormhole = _wormholeFactory.Create(square, WormholeDirection.Forward);
                board.Ladders.Add(square, wormhole.Target);
            }
        }

        private int GenerateSquare(Board board)
        {
            int square = 0;
            do
            {
                square = new Random().Next(_gameSettings.SquaresOnBoard);
            } while (board.Ladders.Select(x => x.Key).Contains(square) || board.Ladders.Select(x => x.Key).Contains(square));

            return square;
        }

        private void PlaceSnakes(Board board)
        {
            for (int i = 1; i <= _gameSettings.SnakeCount; i++)
            {
                int square = new Random().Next(_gameSettings.SquaresOnBoard);
                Wormhole wormhole = _wormholeFactory.Create(square, WormholeDirection.BackWard);
                board.Snakes.Add(square, wormhole.Target);
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
