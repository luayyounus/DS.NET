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

            int moves = 0;

            // Moving up
            if (h + 2 <= 8 && v + 1 <= 8) moves++;
            if (h + 2 <= 8 && v - 1 >= 1) moves++;

            // Moving down
            if (h - 2 >= 1 && v + 1 <= 8) moves++;
            if (h - 2 >= 1 && v - 1 >= 1) moves++;
            
            // Moving right
            if (v + 2 <= 8 && h + 1 <= 8) moves++;
            if (v + 2 <= 8 && h - 1 >= 1) moves++;

            // Moving left
            if (v - 2 >= 1 && h + 1 <= 8) moves++;
            if (v - 2 >= 1 && h - 1 >= 1) moves++;

            return moves;
        }
    }
}