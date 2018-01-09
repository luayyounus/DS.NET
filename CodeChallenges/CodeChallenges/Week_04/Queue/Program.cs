using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_04.Queue
{
    class Program
    {
        public static void Main(string[] args)
        {
            QueueQ que = new QueueQ();

            que.Enqueue(8);
            que.Enqueue(6);
            que.Enqueue(77);

            // Dequeuing 8
            QNode temp = que.Dequeue();
            Console.WriteLine(temp.Value);

            // Dequeuing 6
            temp = que.Dequeue();
            Console.WriteLine(temp.Value);

            // Peeking the value 77
            temp = que.Peek();
            Console.WriteLine(temp.Value);

            Console.ReadLine();
        }
    }
}
