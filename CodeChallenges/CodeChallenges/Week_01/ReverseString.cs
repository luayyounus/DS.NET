using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Reversed word of 'STAR' is: {Reverse("STAR")}");
            Console.ReadLine();
        }

        static string Reverse(string word)
        {
            char[] wordArray = word.ToCharArray();
            char[] reverseArray = new char[word.Length];
            for (int i = 0, j = word.Length -1; i < word.Length; i++, j--)
            {
                reverseArray[i] = word[j];
            }
            return new String(reverseArray);
        }
    }
}
