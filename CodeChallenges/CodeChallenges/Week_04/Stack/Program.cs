using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_04.Stack
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stack s = new Stack();

            StackNode tempNode = null;

            // Push to stack
            s.Push(4);
            s.Push(5);
            s.Push(8);

            // Peeking the top of the stack
            tempNode = s.Peek();

            Console.WriteLine("Expected value is 8, Actual value is " + tempNode.Value);

            // Popping out from the stack
            s.Pop();

            tempNode = s.Peek();

            Console.WriteLine("Expected value is 5, Actual value is " + tempNode.Value);

            Console.ReadLine();
        }
    }
}
