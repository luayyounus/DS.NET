using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_04.Queue
{
    public class QueueQ
    {
        public QNode Head;
        public QNode Tail;

        public void Enqueue(int n)
        {
            QNode newNode = new QNode { Value = n };

            if (Head == null)
            {
                Head = newNode;
                Tail = Head;
                return;
            }
            Tail.Next = newNode;
            Tail = newNode;
        }

        public QNode Dequeue()
        {
            QNode dequeuedNode = Head;
            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            return dequeuedNode;
        }

        public QNode Peek()
        {
            return Head;
        }
    }
}
