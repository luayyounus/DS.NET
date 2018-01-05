using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_03
{
    public class DLL
    {
        public DLLNode Head = null;

        // Add item to the beginning of the LinkedList
        public void AddFirst(int n)
        {
            DLLNode newNode = new DLLNode { Val = n };

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }

    }
}
