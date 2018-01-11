using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_04.Stack
{
    public class Stack
    {
        public StackNode Head;

        public void Push(int n)
        {
            StackNode newNode = new StackNode
            {
                Value = n,
                Next = Head
            };
            Head = newNode;
        }

        public StackNode Pop()
        {
            StackNode poppedNode = Head;
            Head = Head?.Next;
            return poppedNode;
        }

        public StackNode Peek()
        {
            return Head;
        }
    }
}
