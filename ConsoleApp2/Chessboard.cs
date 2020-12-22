using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Chessboard
    {
       
        public Chessboard()
        {
            CanPutPositions = new List<KeyValuePair<int, int>>();
            for (int j = 1; j <= 8; j++)
            {
                for (int i = 1; i <=8; i++)
                {
                    CanPutPositions.Add(new KeyValuePair<int, int>(i,j));
                }
            }
            QueenPositions = new List<KeyValuePair<int, int>>();
        }
        public Chessboard(Chessboard board,KeyValuePair<int,int> position)
        {
            CanPutPositions = board.CanPutPositions.Except(new[] { position }).ToList();
            QueenPositions= new List<KeyValuePair<int, int>>(board.QueenPositions.Concat(new [] { position }));
            for (int y = 1; y <=8 ; y++)
            {
                for (int x = 1; x <= 8; x++)
                {
                    if (x == position.Key || //橫線 
                        y == position.Value || //直線
                        x+y == position.Key + position.Value ||//左下到右上 
                        x-y == position.Key - position.Value //左上到右下
                        )                   
                    {
                        if (CanPutPositions.Where(can => can.Key == x && can.Value == y).Any())
                        {
                            CanPutPositions.Remove(new KeyValuePair<int, int>(x,y));
                        }
                    }
                   
                }
            }

        }
        public List<KeyValuePair<int, int>> CanPutPositions { get; set; }
        public List<KeyValuePair<int, int>> QueenPositions { get; set; }
        public bool QueenCountEqualEight => QueenPositions.Count == 8;
        public bool NoSolution => CanPutPositions.Count < 8 - QueenPositions.Count;

    }
}
