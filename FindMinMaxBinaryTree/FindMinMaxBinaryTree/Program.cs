using System;
using System.Collections;
using System.Collections.Generic;

namespace FindMinMaxBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node
            {
                Value = -4,
                Left = new Node() {Value = -2943},
                Right = new Node() {Value = 23498}
            };
            root.Left.Left = new Node() {Value = -329};
            root.Left.Right = new Node() {Value = 1};
            root.Right.Right = new Node() {Value = 21};
            root.Right.Left = new Node() {Value = -4398};

            int resultMax = FindMax(root);
            Console.WriteLine(resultMax);

            int resultMin = FindMin(root);
            Console.WriteLine(resultMin);

            Console.ReadLine();
        }

        public static int FindMax(Node root)
        {
            int max = int.MinValue;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                Node currentNode = q.Dequeue();
                if (currentNode.Value > max) max = currentNode.Value;
                if(currentNode.Left != null) q.Enqueue(currentNode.Left);
                if(currentNode.Right != null) q.Enqueue(currentNode.Right);
            }
            return max;
        }

        public static int FindMin(Node root)
        {
            int min = int.MaxValue;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                Node currentNode = q.Dequeue();
                if (currentNode.Value < min) min = currentNode.Value;
                if (currentNode.Left != null) q.Enqueue(currentNode.Left);
                if (currentNode.Right != null) q.Enqueue(currentNode.Right);
            }
            return min;
        }
    }

    internal class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
    }
}
