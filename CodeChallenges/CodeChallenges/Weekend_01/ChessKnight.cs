using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenges
{
    // Kata on Code Wars https://www.codewars.com/kata/chess-fun-number-3-chess-knight/csharp
    class ChessKnight
    {
        private static void Main(string[] args)
        {
            int result = CheckPossibleMoves("a4");
            Console.WriteLine($"Number of possible moves: {result}");
            Console.ReadLine();
        }

        static int CheckPossibleMoves(string cell)
        {
            int v = cell[0] - 96; // Converting ASCII char a to 1, b to 2 and such...
            int h = cell[1] - 48; // Converting ASCII char '1' to 1, '2' to 2 and such... 

            int totalMoves = 0;

            // Moving up
            if (h + 2 <= 8)
            {
                if (v + 1 <= 8) totalMoves++;
                if (v - 1 >= 1) totalMoves++;
            }
            // Moving down
            if (h - 2 >= 1)
            {
                if (v + 1 <= 8) totalMoves++;
                if (v - 1 >= 1) totalMoves++;
            }
            // Moving right
            if (v + 2 <= 8)
            {
                if (h + 1 <= 8) totalMoves++;
                if (h - 1 >= 1) totalMoves++;
            }
            // Moving left
            if (v - 2 >= 1)
            {
                if (h + 1 <= 8) totalMoves++;
                if (h - 1 >= 1) totalMoves++;
            }
            return totalMoves;
        }
    }
}
