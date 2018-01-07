using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenges.Weekend_02_03
{
    class PlayPass
    {
        public static void Main(string[] args)
        {
            string result = PlayPassphrase("MY GRANMA CAME FROM NY ON THE 23RD OF APRIL 2015", 2);
            Console.WriteLine(result);
            
            Console.Read();
        }

        // Kata https://www.codewars.com/kata/playing-with-passphrases/train/csharp
        public static string PlayPassphrase(string s, int n)
        {
            char[] complement = new[] { '9', '8', '7', '6', '5', '4', '3', '2', '1', '0'};
            char[] charArray = s.ToLower().ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(charArray[i]))
                {
                    int ascii = charArray[i] + n;
                    if (ascii > 122) ascii -= 26;
                    if (i % 2 == 0)
                        charArray[i] = char.ToUpper((char) ascii);
                    else
                        charArray[i] = char.ToLower((char)ascii);
                }
                if (char.IsDigit(charArray[i]))
                    charArray[i] = complement[charArray[i] - '0'];
            }
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
