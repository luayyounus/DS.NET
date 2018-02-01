using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArrayToBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Convert array to binary tree!");

            int[] x = new[] {1, 2, 3, 4, 5, 6, 7};
            Node newTree = ConvertArrayToBinaryTree(x);
            PrintPretty("", true, newTree);
            Console.ReadLine();
        }

        public static void PrintPretty(string indent, bool last, Node root)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(root.Value);
            if (root.Left != null) PrintPretty(indent, true, root.Left);
            if (root.Right != null) PrintPretty(indent, true, root.Right);
        }


        public static Node ConvertArrayToBinaryTree(int[] sortedArray)
        {
            if (sortedArray.Length == 0) return null;
            
            // Starting index at the beginning of the Sorted Array
            int index = 0;

            // Setting the root with the first Value
            Node root = new Node(sortedArray[index]);
            index++;

            // Creating a Queue to Add Nodes equally
            Queue<Node> q = new Queue<Node>();

            // Add the root to the queue
            q.Enqueue(root);

            // if not looped over the whole array then get in the while loop
            while(index < sortedArray.Length)
            {
                // if queue is empty then leave and return root
                if (q.Count <= 0) break;

                // dequeue node to be current
                Node current = q.Dequeue();

                // if current left is null then add the node ( basically it's always going to be null )
                if (current.Left == null)
                {
                    if (index >= sortedArray.Length) break;
                    current.Left = new Node(sortedArray[index]);
                    index++;
                    q.Enqueue(current.Left);
                }

                // if current right is null then add the node ( basically it's always going to be null )
                if (current.Right == null)
                {
                    if (index >= sortedArray.Length) break;
                    current.Right = new Node(sortedArray[index]);
                    index++;
                    q.Enqueue(current.Right);
                }
            }
            return root;
        }
    }

    internal class Node
    {
        public int Value;
        public Node Left, Right;

        public Node(int x)
        {
            Value = x;
        }
    }
}
