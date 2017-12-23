using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace CodeChallenges
{
    class OccurancesCount
    {
        static void Main(string[] args)
        {
            int[] numArray = { 1, 1, 3, 3, 3, 4, 4, 5, 6, 6 };
            PrintOccurances(numArray);
            Console.ReadLine();
        }

        static void PrintOccurances(int[] input)
        {
            int counter = 1;
            int prev, curr;
            prev = input[0];
            curr = input[1];

            int index = 1;
            while (index < input.Length -1)
            {
                if (curr != prev)
                {
                    Console.WriteLine($"{prev}:{counter} occurances");
                    counter = 0;
                }
                counter++;
                prev = curr;
                curr = input[++index];
            }
            Console.WriteLine($"{prev}:{++counter} occurances");
        }
    }
}
