using System;

namespace CodeChallenges
{
    // Kata on Code Wars https://www.codewars.com/kata/chess-fun-number-3-chess-knight/csharp
    public class ChessKnight
    {
        private static void Main(string[] args)
        {
            int test1 = CheckPossibleMoves("a4");
            Console.WriteLine($"Number of possible moves: {test1}");

            int test2 = CheckPossibleMoves2("a4");
            Console.WriteLine($"Number of possible moves: {test2}");

            Console.ReadLine();
        }

        public static int CheckPossibleMoves(string cell)
        {
            int v = cell[0] - 96; // Converting ASCII char a to 1, b to 2 and such...
            int h = cell[1] - 48; // Converting ASCII char '1' to 1, '2' to 2 and such... 

            int moves = 0;

            // Moving up
            if (h + 2 <= 8 && h + 2 >= 1 && v + 1 <= 8 && v + 1 >= 1) moves++;
            if (h + 2 <= 8 && h + 2 >= 1 && v - 1 <= 8 && v - 1 >= 1) moves++;

            // Moving down
            if (h - 2 <= 8 && h - 2 >= 1 &&  v + 1 <= 8 && v + 1 >= 1) moves++;
            if (h - 2 <= 8 && h - 2 >= 1 && v - 1 <= 8 && v - 1 >= 1) moves++;
            
            // Moving right
            if (v + 2 <= 8 && v + 2 >= 1 && h + 1 <= 8 && h + 1 >= 1) moves++;
            if (v + 2 <= 8 && v + 2 >= 1 && h - 1 <= 8 && h - 1 >= 1) moves++;

            // Moving left
            if (v - 2 <= 8 && v - 2 >= 1 && h + 1 <= 8 && h + 1 >= 1) moves++;
            if (v - 2 <= 8 && v - 2 >= 1 && h - 1 <= 8 && h - 1 >= 1) moves++;

            return moves;
        }

        public static int CheckPossibleMoves2(string cell)
        {
            int x = cell[0] - 96;
            int y = cell[1] - 48;

            int[][] allPossibleMoves = {
                new int[] {x + 2, y - 1},
                new int[] {x + 2, y + 1},
                new int[] {x - 2, y - 1},
                new int[] {x - 2, y + 1},
                new int[] {x + 1, y - 2},
                new int[] {x + 1, y + 2},
                new int[] {x - 1, y - 2},
                new int[] {x - 1, y + 2}
            };

            int movesCount = 0;
            foreach (int[] move in allPossibleMoves)
            {
                movesCount += (move[0] >= 1 && move[0] <= 8 && move[1] >= 1 && move[1] <= 8) ? 1 : 0;
            }

            return movesCount;
        }
    }
}