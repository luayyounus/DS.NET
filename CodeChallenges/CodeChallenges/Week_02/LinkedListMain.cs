using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_02
{
    class LinkedListMain
    {
        static void Main(string[] args)
        {
            SLL sll = new SLL();
            
            Console.WriteLine("Add First");
            sll.AddFirst(4);
            sll.AddFirst(5);
            PrintLinked(sll.Head);

            Console.WriteLine("Add Last");
            sll.AddLast(3);
            sll.AddLast(9);
            PrintLinked(sll.Head);

            Console.WriteLine("Add before");
            sll.AddBefore(8, 9);
            PrintLinked(sll.Head);

            Console.WriteLine("Add After");
            sll.AddAfter(10, 9);
            PrintLinked(sll.Head);

            Console.WriteLine("Remove Node");
            sll.RemoveNode(9);
            PrintLinked(sll.Head);

            Console.WriteLine("Get Middle Node");
            SLLNode middle = sll.GetMiddle();
            Console.WriteLine(middle.Value);

            Console.WriteLine("Get Node nth from the End");
            SLLNode nth = sll.GetNodeFromEnd(3);
            Console.WriteLine(nth.Value);

            Console.ReadLine();
        }

        static void PrintLinked(SLLNode node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
