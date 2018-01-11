using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CodeChallenges.Week_04
{
    public class EqualBrackets
    {
        public static void Main(string[] args)
        {
            string[] brackets = { "[{{{{]}", "{[[[]]]})", "{[[[]]]})", "{[]}" };

            var sw = Stopwatch.StartNew();
            foreach (string s in brackets)
            {
                var result = CheckBrackets(s);
                Console.WriteLine($"Is {s} balanced? " + result.ToString() + " - Execution Time in ms:" + sw.ElapsedMilliseconds);
            }
            sw.Stop();

            Console.ReadLine();
        }

        public static bool CheckBrackets(string input)
        {
            Stack<char> s = new Stack<char>();
            foreach (char c in input)
            {
                if (c == '[')
                    s.Push(']');
                else if (c == '{')
                    s.Push('}');
                else if (c == '(')
                    s.Push(')');
                else if((s.Count == 0) || (c != s.Pop()))
                    return false;
            }
            if (s.Count != 0) return false;
            return true;
        }
    }
}
