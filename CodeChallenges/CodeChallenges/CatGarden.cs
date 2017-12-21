using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges
{
    class CatGarden
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("First Solution");
            CatGardenFirstPattern('x', 'y');
            Console.ReadLine();

            Console.WriteLine("Second Solution");
            CatGardenSecondPattern('x', 'y');
            Console.ReadLine();
        }

        static void CatGardenFirstPattern(char charOne, char charTwo)
        {
            char c = charOne;
            for (int i = 1; i < 26; i++)
            {
                Console.Write(c);
                if (i % 5 == 0)
                {
                    Console.WriteLine();
                    c = c == 'x' ? charTwo : charOne;
                }
            }
        }

        static void CatGardenSecondPattern(char charOne, char charTwo)
        {
            char c = charOne;
            for (int i = 1; i < 26; i++)
            {
                Console.Write(c);
                if (i % 5 == 0)
                {
                    Console.WriteLine();
                }
                c = c == 'x' ? charTwo : charOne;
            }
        }
    }
}
