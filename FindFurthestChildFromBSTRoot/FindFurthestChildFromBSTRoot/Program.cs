using System;
using System.Collections.Generic;

namespace FindFurthestChildFromBSTRoot
{
    class Program
    {

        static int level = -1;
        static int maxLevel = -1;
        static Node result = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Convert array to binary tree!");

            int[] x = new[] { 1, 2, 3, 4, 5, 6, 7, 9 };
            Node newTree = ConvertArrayToBinaryTree(x, 0, x.Length - 1);
            PrintPretty("", true, newTree);

            //FindFurthestChild(newTree, level, maxLevel, null);
            //Console.WriteLine(result.Value);

            FindFurthestChildBreadth(newTree);
            Console.WriteLine(result.Value);

            Console.ReadLine();
        }

        // Using recursion
        public static void FindFurthestChild(Node root, int level, int maxLevel, Node furthest)
        {
            if(root != null)
            {
                FindFurthestChild(root.Left, level++, maxLevel, furthest);
                if (level > maxLevel)
                {
                    result = root;
                    maxLevel = level;
                }
                FindFurthestChild(root.Right, level, maxLevel, furthest);
            }
        }

        //using Breadth first
        public static void FindFurthestChildBreadth(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            Node current = root;
            q.Enqueue(current);

            while(q.Count > 0)
            {
                result = q.Dequeue();
                if (result.Left != null) q.Enqueue(result.Left);
                if (result.Right != null) q.Enqueue(result.Right);
            }
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

        public static Node ConvertArrayToBinaryTree(int[] sortedArray, int start, int end)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            Node nodeToAttach = new Node(sortedArray[mid]);
            nodeToAttach.Left = ConvertArrayToBinaryTree(sortedArray, start, mid - 1);
            nodeToAttach.Right = ConvertArrayToBinaryTree(sortedArray, mid + 1, end);
            return nodeToAttach;
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
