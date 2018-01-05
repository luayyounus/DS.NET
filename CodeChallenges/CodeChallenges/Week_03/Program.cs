using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_03
{
    class Program
    {
        public static void Main(string[] args)
        {
            DLL dll = new DLL();
            Console.WriteLine("Add First");
            dll.AddFirst(4);
            dll.AddFirst(2);
            dll.AddFirst(5);
            PrintLinked(dll.Head);

            Console.ReadLine();
        }

        static void PrintLinked(DLLNode node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Val);
                node = node.Next;
            }
        }
    }
}
