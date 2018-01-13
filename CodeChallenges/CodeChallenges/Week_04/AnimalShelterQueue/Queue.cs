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
            QNode originalTail = Tail;
            QNode dequeuedDog = Dequeue_Any();
            QNode tempDog = null;
            bool oldestDogFound = false;
            while (dequeuedDog != originalTail)
            {
                if (dequeuedDog.AnimalName == "dog" && oldestDogFound != true)
                {
                    tempDog = dequeuedDog;
                    dequeuedDog = Dequeue_Any();
                    oldestDogFound = true;
                    continue;
                }
                Enqueue(dequeuedDog.AnimalName);
                dequeuedDog = Dequeue_Any();
            }
            Enqueue(dequeuedDog.AnimalName);

            return tempDog;
        }

        public QNode Dequeue_Cat()
        {
            QNode originalTail = Tail;
            QNode dequeuedCat = Dequeue_Any();
            QNode tempCat = null;
            bool oldestCatFound = false;
            while (dequeuedCat != originalTail)
            {
                if (dequeuedCat.AnimalName == "cat" && oldestCatFound != true)
                {
                    tempCat = dequeuedCat;
                    dequeuedCat = Dequeue_Any();
                    oldestCatFound = true;
                    continue;
                }
                Enqueue(dequeuedCat.AnimalName);
                dequeuedCat = Dequeue_Any();
            }
            Enqueue(dequeuedCat.AnimalName);

            return tempCat;
        }
    }
}
