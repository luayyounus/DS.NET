using System;
using System.Collections.Generic;

namespace BreadthFirstTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BreadthFirst b = new BreadthFirst();

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

            Console.WriteLine("\n Breadth First a Tree");
            b.OutputTree(root);
            
            Console.ReadLine();
        }
    }

    internal class BreadthFirst
    {
        public void OutputTree(TNode root)
        {
            Queue<TNode> q = new Queue<TNode>();
            q.Enqueue(root);
            while(q.Count != 0)
            {
                TNode temp = q.Dequeue();
                Console.WriteLine(temp.Val);
                if (temp.Left != null) q.Enqueue(temp.Left);
                if (temp.Right != null) q.Enqueue(temp.Right);
            }
        }
    }

    internal class TNode
    {
        public TNode Left, Right;
        public int Val;
        public TNode(int val)
        {
            Val = val;
        }
    }
}
