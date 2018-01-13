using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_04.AnimalShelterQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue que = new Queue();
            que.Enqueue("rabbit");
            que.Enqueue("dog");
            que.Enqueue("cat");
            que.Enqueue("lizard");
            que.Enqueue("dog");
            que.Enqueue("dog");

            que.Dequeue_Any();
            Console.WriteLine("\nDequeued oldest Animal in the queue");

            que.Dequeue_Dog();
            Console.WriteLine("\nDequeued oldest Dog in the queue");

            que.Dequeue_Cat();
            Console.WriteLine("\nDequeuing oldest Cat in the queue");

            Console.WriteLine("\nPrinting what is left in the queue");
            while (que.Head != null)
            {
                Console.WriteLine(que.Dequeue_Any().AnimalName);
            }

            Console.ReadLine();
        }
    }
}
