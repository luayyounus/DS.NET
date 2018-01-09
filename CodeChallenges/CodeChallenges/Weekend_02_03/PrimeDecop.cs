using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Weekend_02_03
{
    // Kata on Code Wars https://www.codewars.com/kata/primes-in-numbers/csharp
    public static class PrimeDecop
    {
        public static void Main(string[] args)
        {
            string result = Factors(12);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static string Factors(int lst)
        {
            Dictionary<int, int> factors = new Dictionary<int, int>();

            while (lst != 1)
            {
                for (int i = 2; i <= lst; ++i)
                {
                    if (lst % i == 0)
                    {
                        if (factors.ContainsKey(i))
                            factors[i] += 1;
                        else
                            factors[i] = 1;

                        lst = lst / i;
                        break;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<int, int> kvp in factors)
            {
                sb.Append(kvp.Value == 1 ? $"({kvp.Key})" : $"({kvp.Key}**{kvp.Value})");
            }
            return sb.ToString();
        }
    }
}
