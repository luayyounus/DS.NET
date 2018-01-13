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
            string testString = "[{({((((((})}]";

            var sw = Stopwatch.StartNew();

            // Checking with Check Brackets Method
            bool result = CheckBrackets(testString);
            Console.WriteLine("Are the brackets matching with CheckBrackets? " + result.ToString() +
                              " - Execution Time in ms:" + sw.ElapsedMilliseconds);

            // Checking with Brackets Pairs Method
            bool result2 = CheckBracketsPairs(testString);
            Console.WriteLine("Are the brackets matching with CheckBracketsPairs? " + result2.ToString() +
                                " - Execution Time in ms:" + sw.ElapsedMilliseconds);
        
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
                else if (s.Count == 0 || c != s.Pop())
                    return false;
            }
            return s.Count == 0;
        }

        public static bool CheckBracketsPairs(string input)
        {
            Stack<char> s = new Stack<char>();
            foreach (char c in input)
            {
                if (c == '[' || c == '{' || c == '(')
                    s.Push(c);
                else
                {
                    string poppedBracket = s.Pop().ToString() + c;
                    if (poppedBracket != "[]" &&
                        poppedBracket != "{}" &&
                        poppedBracket != "()")
                        return false;
                }
            }
            return true;
        }
    }
}
