using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_02
{
    public class SLL
    {
        public SLLNode Head = new SLLNode();

        // Adding int value to the first position in a LinkedList
        public SLLNode AddFirst(int value)
        {
            SLLNode newNode = new SLLNode { Value = value };
            if (Head == null) return newNode;
            newNode.Next = Head;
            Head = newNode;
            return Head;
        }
    }
}
