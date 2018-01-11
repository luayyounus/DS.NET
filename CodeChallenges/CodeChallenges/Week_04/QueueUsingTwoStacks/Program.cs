using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_04.QueueUsingTwoStacks
{
    public class Program
    {
        public void Main(string[] args)
        {
            QueueUsingTwoStacks q = new QueueUsingTwoStacks();
            
            q.Enqueue(2);
            q.Enqueue(623);
            q.Enqueue(53);

            int result = q.Dequeue();
            Console.WriteLine(result);
        }
    }
}
