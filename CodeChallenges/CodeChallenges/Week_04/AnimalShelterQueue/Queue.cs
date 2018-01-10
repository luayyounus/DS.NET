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
            }
            Tail.Next = newNode;
            Tail = newNode;
        }

        public QNode Dequeue_Any()
        {
            if (Head == null) return null;
            QNode animalToReturn = Head;
            if (Head.Next == null)
            {
                Tail = null;
                Head = null;
                return animalToReturn;
            }
            Head = Head.Next;
            return animalToReturn;
        }

        public QNode Dequeue_Dog()
        {
            if (Head == null) return null;
            if (Head.AnimalName == "dog")
            {
                QNode dog = Head;
                if (Tail == Head)
                {
                    Head = null;
                    Tail = null;
                    return dog;
                }
                Head = Head.Next;
                return dog;
            }
            if (Head.Next == null)
            {
                return null;
            }
            QNode current = Head.Next;
            QNode prev = Head;
            while (current != null)
            {
                if (current.AnimalName == "dog")
                {
                    QNode dog = current;
                    if (current == Tail)
                    {
                        Tail = prev;
                    }
                    prev.Next = current.Next;
                    return dog;
                }
                current = current.Next;
                prev = prev.Next;
            }
            return null;
        }

        public QNode Dequeue_Cat()
        {
            if (Head == null) return null;
            if (Head.AnimalName == "cat")
            {
                QNode cat = Head;
                if (Tail == Head)
                {
                    Head = null;
                    Tail = null;
                    return cat;
                }
                Head = Head.Next;
                return cat;
            }
            if (Head.Next == null)
            {
                return null;
            }
            QNode current = Head.Next;
            QNode prev = Head;
            while (current != null)
            {
                if (current.AnimalName == "cat")
                {
                    QNode cat = current;
                    if (current == Tail)
                    {
                        Tail = prev;
                    }
                    prev.Next = current.Next;
                    return cat;
                }
                current = current.Next;
                prev = prev.Next;
            }
            return null;
        }
    }
}
