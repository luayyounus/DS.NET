using System;
using System.Collections.Generic;

namespace CodeChallenges.Weekend_02_03
{
    public class IsMyFriendCheating
    {
        public static void Main(string[] args)
        {
            List<long[]> result = RemovNumbers(145);
            foreach (long[] arr in result)
            {
                Console.WriteLine(arr[0]);
                Console.WriteLine(arr[1]);
            }
            Console.ReadLine();
        }
        public static List<long[]> RemovNumbers(long n)
        {
            List<long[]> pairs = new List<long[]>();

            // Summation without performing n number of additions
            long sum = n * (n + 1) / 2;
            long sumExcluded = sum;
            for (long i = 1; i < n; i++)
            {
                for (long j = i+1; j <= n; j++)
                {
                    sumExcluded = sumExcluded - i - j;
                    long possiblePairMultiplied = i * j;
                    if (sumExcluded == possiblePairMultiplied)
                    {
                        pairs.Add(new []{i,j});
                        pairs.Add(new []{j,i});
                    }
                    sumExcluded = sum;
                }
            }
            return pairs;
        }
    }
}
