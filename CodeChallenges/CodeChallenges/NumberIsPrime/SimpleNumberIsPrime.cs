using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.NumberIsPrime
{
    class SimpleNumberIsPrime
    {
        //Using Soner routine, but we will run until i is equal to Math.Ceiling(Math.Sqrt(number)) that is the trick for the naive solution
        public static bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Another Way
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
