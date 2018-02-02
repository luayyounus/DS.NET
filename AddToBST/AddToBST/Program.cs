using System;

namespace AddToBST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BST bst = new BST();

            bst.Root = bst.AddNumToBst(bst.Root, 3);
            bst.Root = bst.AddNumToBst(bst.Root, 1);
            bst.Root = bst.AddNumToBst(bst.Root, 9);
            bst.Root = bst.AddNumToBst(bst.Root, -32);
            bst.Root = bst.AddNumToBst(bst.Root, 0);

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
