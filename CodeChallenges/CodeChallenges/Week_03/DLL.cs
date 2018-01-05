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

        // Add last item to the linkedlist
        public void AddLast(int n)
        {
            DLLNode newNode = new DLLNode {Val = n};

            if (Head == null)
            {
                Head = newNode;
                return;
            }
            DLLNode current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            newNode.Prev = current;
        }

        // Add item before targeted number
        public void AddBefore(int n, int target)
        {
            if (Head == null) return;
            DLLNode newNode = new DLLNode { Val = n };
            DLLNode current = Head;
            while (current != null)
            {
                if (current.Val == target)
                {
                    newNode.Prev = current.Prev;
                    current.Prev.Next = newNode;
                    newNode.Next = current;
                    current.Prev = newNode;
                    return;
                }
                current = current.Next;
            }
        }

        // Add item after targeted number
        public void AddAfter(int n, int target)
        {
            if (Head == null) return;
            DLLNode newNode = new DLLNode { Val = n };
            DLLNode current = Head;
            while (current != null)
            {
                if (current.Val == target)
                {
                    if (current.Next != null)
                        current.Next.Prev = newNode;
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    newNode.Prev = current;
                    return;
                }
                current = current.Next;
            }
        }

        // Remove item from Doubly Linked List
        public void Remove(int n)
        {
            if (Head == null) return;
            if (Head.Val == n)
            {
                Head = Head.Next;
                return;
            }
            DLLNode curr = Head;
            while (curr.Next != null)
            {
                curr = curr.Next;
                if (curr.Val != n) continue;
                if (curr.Next != null)
                {
                    curr.Next.Prev = curr.Prev;
                }
                if (curr.Prev != null)
                {
                    curr.Prev.Next = curr.Next;
                }
                return;
            }
            Console.WriteLine("Not Found");
        }
    }
}
