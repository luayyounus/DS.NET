using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_04.Stack
{
    public class Stack
    {
        public StackNode Head = null;

        public void Push(int n)
        {
            StackNode newNode = new StackNode
            {
                Value = n,
                Next = Head
            };
            Head = newNode;
        }

        public void Pop()
        {
            Head = Head?.Next;
        }

        public StackNode Peek()
        {
            return Head;
        }
    }
}
