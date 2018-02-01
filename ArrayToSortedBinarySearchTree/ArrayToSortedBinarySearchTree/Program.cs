using System;

namespace ArrayToSortedBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Convert array to binary tree!");

            int[] x = new[] { 1, 2, 3, 4, 5, 6, 7 };
            Node newTree = ConvertArrayToBinaryTree(x, 0, x.Length - 1);
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
