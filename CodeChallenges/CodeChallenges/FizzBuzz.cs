using System;

namespace CodeChallenges
{
    class FizzBuzz
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"FizzBuzz for number 1: {CheckNumber(1)}");
            Console.ReadLine();
            Console.WriteLine($"FizzBuzz for Checking number 3: {CheckNumber(3)}");
            Console.ReadLine();
            Console.WriteLine($"FizzBuzz for Checking number 15: {CheckNumber(15)}");
            Console.ReadLine();
        }

        static string CheckNumber(int num)
        {
            if (num % 3 == 0 && num % 5 == 0)
                return "FizzBuzz";
            if (num % 3 == 0)
                return "Fizz";
            if (num % 5 == 0)
                return "Buzz";

            return $"{num} is non-divisible";
        }
    }
}
