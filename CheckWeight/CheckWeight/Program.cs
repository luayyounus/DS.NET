using System;

namespace CheckWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Weigh the number and tell me true or false   !");

            int[] x = new[] { 1, 2, 3, 4, 5, 6, 7 };
            Node newTree = ConvertArrayToBinaryTree(x, 0, x.Length - 1);
            PrintPretty("", true, newTree);

            // 7 should exist and return true
            bool result = CheckWeight(newTree, 7);
            Console.WriteLine(result.ToString());

            Console.ReadLine();
        }

        // Check weight
        private static bool CheckWeight(Node root, int sum)
        {
            if (root == null) return false;
            int sub = sum - root.Value;
            if (sub == 0 && root.Left == null && root.Right == null) return true;
            bool left = CheckWeight(root.Left, sub);
            bool right = CheckWeight(root.Right, sub);
            return left || right;
        }

        // Create the BST
        public static Node ConvertArrayToBinaryTree(int[] sortedArray, int start, int end)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            Node nodeToAttach = new Node(sortedArray[mid]);
            nodeToAttach.Left = ConvertArrayToBinaryTree(sortedArray, start, mid - 1);
            nodeToAttach.Right = ConvertArrayToBinaryTree(sortedArray, mid + 1, end);
            return nodeToAttach;
        }

        // Ouput the tree
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
    }
    class Node
    {
        public int Value { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public Node(int num)
        {
            Value = num;
        }
    }
}
