using System;

namespace DeleteANodeFromBST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BST bst = new BST();

            Console.WriteLine("Adding to Bst");
            bst.Root = bst.AddNumToBst(bst.Root, 3);
            bst.Root = bst.AddNumToBst(bst.Root, 1);
            bst.Root = bst.AddNumToBst(bst.Root, 9);
            bst.Root = bst.AddNumToBst(bst.Root, -32);
            bst.Root = bst.AddNumToBst(bst.Root, 0);

            Console.WriteLine("Removing from Bst");
            bst.Root = bst.RemoveNodeFromBst(bst.Root, 3);
            bst.PrintPretty("", true, bst.Root);
            Console.ReadLine();
        }
    }

    public class BST
    {
        public Node Root = null;

        public Node AddNumToBst(Node root, int x)
        {
            if (root == null) root = new Node(x);

            if (x < root.Value)
                root.Left = AddNumToBst(root.Left, x);
            if (x > root.Value)
                root.Right = AddNumToBst(root.Right, x);
            return root;
        }

        public Node RemoveNodeFromBst(Node root, int x)
        {
            if (root == null) return null;

            if (x < root.Value) root.Left = RemoveNodeFromBst(root.Left, x);
            else if (x > root.Value) root.Right = RemoveNodeFromBst(root.Right, x);
            else
            {
                if (root.Left == null) return root.Right;
                else if (root.Right == null) return root.Left;
                while (root.Right.Left != null) root.Right = root.Right.Left;
                Node minNode = root.Right;
                root.Value = minNode.Value;
                root.Right = RemoveNodeFromBst(root.Right, root.Value);
            }
            return root;
        }

        public void PrintPretty(string indent, bool last, Node root)
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

    public class Node
    {
        public int Value;
        public Node Right;
        public Node Left;

        public Node(int value)
        {
            Value = value;
        }
    }
}
