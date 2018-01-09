using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenges.Weekend_02_03
{
    // Kata on Code Wars https://www.codewars.com/kata/replace-with-alphabet-position/csharp
    class ReplaceWithAlphabetPosition
    {
        public static void Main(string[] args)
        {
            string result = AlphabetPosition("Micky mouse lives in Hollywood. right?");
            Console.WriteLine(result);

            string result2 = AlphabetPositionWithLinq("Micky mouse lives in Hollywood. right?");
            Console.WriteLine(result2);
            Console.Read();
        }

        public static string AlphabetPosition(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text.ToLower())
            {
                int charValue = (int) c;
                if (charValue >= 97 && charValue <= 122)
                {
                    sb.Append(charValue - 96 + " ");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string AlphabetPositionWithLinq(string text)
        {
            return string.Join(" ", text.ToLower().Where(char.IsLetter).Select(c => c - 96));
        }
    }
}
