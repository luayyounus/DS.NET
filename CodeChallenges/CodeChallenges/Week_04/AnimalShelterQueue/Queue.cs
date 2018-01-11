using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_04.AnimalShelterQueue
{
    public class Queue
    {
        public QNode Head = null;
        public QNode Tail = null;


        public void Enqueue(string animal)
        {
            QNode newNode = new QNode { AnimalName = animal };

            if (Head == null)
            {
                Head = newNode;
                Tail = Head;
                return;
            }
            Tail.Next = newNode;
            Tail = newNode;
        }

        public QNode Dequeue_Any()
        {
            QNode anyAnimal = Head;
            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            return anyAnimal;
        }

        public QNode Dequeue_Dog()
        {
            QNode dequeuedDog = Dequeue_Any();
            QNode tempDog = null;
            while (dequeuedDog != Tail)
            {
                if (dequeuedDog.AnimalName == "dog")
                {
                    tempDog = dequeuedDog;
                    dequeuedDog = Dequeue_Any();
                    continue;
                }
                Enqueue(dequeuedDog.AnimalName);
                dequeuedDog = Dequeue_Any();
            }

            return tempDog;
        }

        public QNode Dequeue_Cat()
        {
            QNode dequeuedCat = Dequeue_Any();
            QNode tempCat = null;
            while (dequeuedCat != Tail)
            {
                if (dequeuedCat.AnimalName == "cat")
                {
                    tempCat = dequeuedCat;
                    dequeuedCat = Dequeue_Any();
                    continue;
                }
                Enqueue(dequeuedCat.AnimalName);
                dequeuedCat = Dequeue_Any();
            }

            return tempCat;
        }
    }
}
