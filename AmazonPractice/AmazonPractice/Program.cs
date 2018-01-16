using System;
using System.Collections.Generic;

namespace AmazonPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "hello world!";

            // 3 - Reverse Words in String in O(1) no extra space
            char[] result3 = ReverseWords(a.ToCharArray());

            // 2 - Reverse a string
            string result2 = ReverseString("Hello");

            // 1 - First Unique Character in a String
            int result = ReturnFirstUniqueChar("hello");
            Console.ReadLine();
        }

        // 3 - Took me 7 Minutes
        public static char[] ReverseWords(char[] str)
        {
            int[] s = new int[3];
            str = ReverseString3(str);
            int i = 0;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == ' ')
                {
                    ReversePartial(str, i, j - 1);
                    i = j + 1;
                }
            }
            ReversePartial(str, i, str.Length - 1);
            return str;
        }
        public static void ReversePartial(char[] p, int i, int j)
        {
            while (i < j)
            {
                char temp = p[i];
                p[i] = p[j];
                p[j] = temp;
                i++;
                j--;
            }
        }

        // 2 - Took me 5 minutes
        public static string ReverseString(string input)
        {
            char[] reverseArray = new char[input.Length];
            for (int i = input.Length - 1, j = 0; j < input.Length; i--, j++)
            {
                reverseArray[i] = input[j];
            }
            return new string(reverseArray);
        }
        // 2 - Another way to do it - 2 minutes
        public static string ReverseString2(string input)
        {
            string reversed = "";
            for (int i = input.Length - 1; i >= 0; i--)
                reversed += input[i];
            return reversed;
        }
        // 2 - Another char array solution
        public static char[] ReverseString3(char[] input)
        {
            for (int i = 0, j = input.Length - 1; i < input.Length / 2; i++, j--)
            {
                char temp = input[i];
                input[i] = input[j];
                input[j] = temp;
            }
            return input;
        }
        

        // 1 - Took me 12 minutes
        static int ReturnFirstUniqueChar(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!charCount.ContainsKey(c)) charCount.Add(c, 1);
                else charCount[c] += 1;
            }
            for (int i = 0; i < s.Length; i++)
                if (charCount[s[i]] == 1)
                    return i;
            return -1;
        }
    }
}
