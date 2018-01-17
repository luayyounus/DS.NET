using System;

namespace TreeTraversals
{
    class Program
    {
        static void Main(string[] args)
        {
            Traversals traversals = new Traversals();

            TNode root = new TNode(1);
            TNode left = new TNode(2);
            TNode right = new TNode(3);
            TNode leftLeft = new TNode(4);
            TNode leftRight = new TNode(5);
            TNode rightLeft = new TNode(6);
            TNode rightRight = new TNode(7);

            root.Left = left;
            root.Right = right;

            root.Left.Left = leftLeft;
            root.Left.Right = leftRight;

            root.Right.Left = rightLeft;
            root.Right.Right = rightRight;

            Console.WriteLine("\n PreOrdered Tree");
            traversals.PreOrderTraversal(root);

            Console.WriteLine("\n InOrdered Tree");
            traversals.InOrderTraversal(root);

            Console.WriteLine("\n PostOredered Tree");
            traversals.PostOrderTraversal(root);

            Console.ReadLine();
        }
    }
}
