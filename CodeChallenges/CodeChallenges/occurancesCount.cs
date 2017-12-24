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
            OccurancesAllEdgeCases(numArray);
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

        // int[] numArray = { 1, 1, 3, 3, 3, 4, 4, 5, 6, 6 , 1, 1 };

        // Here I took care of all edge cases available
        static void OccurancesAllEdgeCases(int[] input)
        {
            int counter = 0;
            StringBuilder history = new StringBuilder();

            foreach (int num in input)
            {
                if (history.ToString().Contains($"{num}")) continue;
                int currentNumber = num;
                foreach (int innerNum in input)
                {
                    if (num == innerNum)
                        counter++;
                }
                history.Append(num);
                Console.WriteLine($"{currentNumber} : {counter}");
                counter = 0;
            }
        }
    }
}
