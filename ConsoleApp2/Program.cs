using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            var board = new Chessboard();
            Explore(board);

            Console.WriteLine("done");
            Console.ReadLine();
        }
        static int resIdx = 1;
        private static void Explore(Chessboard board)
        {
            var firstQueen = board.QueenPositions.Any()? board.QueenPositions.Last() : new KeyValuePair<int, int>(0,0);
            foreach (var position in board.CanPutPositions.Where(x=>x.Key*10+x.Value>firstQueen.Key*10+firstQueen.Value))
            {
                var newBoard = new Chessboard(board, position);
                
                if (newBoard.QueenCountEqualEight)
                {
                    Console.WriteLine($"success：{resIdx++}");
                    
                    for (int y = 1; y <= 8; y++)
                    {
                        var sb = new StringBuilder();
                        for (int x = 1; x <= 8; x++)
                        {
                            if (newBoard.QueenPositions.Any(a => a.Key == x && a.Value == y))
                            {
                                sb.Append("Q");
                            }
                            else
                            {
                                sb.Append(".");
                            }
                            
                        }
                        Console.WriteLine(sb.ToString());
                    }
                    Console.WriteLine("================");
                
                }
                else if (!newBoard.NoSolution)
                {
                    Explore(newBoard);
                }
            }
        }
    }
}
