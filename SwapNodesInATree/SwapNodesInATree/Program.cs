using System;
using System.Collections;
using System.Collections.Generic;

namespace SwapNodesInATree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(4);
            Node left = new Node(2);
            Node right = new Node(6);
            Node leftLeft = new Node(3);
            Node leftRight = new Node(5);
            Node rightLeft = new Node(1);
            Node rightRight = new Node(7);

            root.Left = left;
            root.Right = right;
            root.Left.Left = leftLeft;
            root.Left.Right = leftRight;
            root.Right.Left = rightLeft;
            root.Right.Right = rightRight;


            Tree t = new Tree();
            t.Root = root;
            t.GetTwoNodesArray(t.Root, 7, 5);

            // output 1
            Console.WriteLine("Before the swap");
            t.InOrderTraversal(t.Root);


            t.SwapTwoLeaves(t.Root);

            // output 2
            Console.WriteLine("After the swap");
            t.InOrderTraversal(t.Root);

            Console.ReadLine();
        }
    }

    public class Tree
    {
        public Node Root = null;

        public Node[] TwoNodes = new Node[2];

        public void SwapWithQueue(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                Node temp = q.Dequeue();
                if (temp.Left != null && temp.Left.Value == TwoNodes[0].Value)
                {
                    temp.Left = TwoNodes[1];
                    //Node temp = TwoNodes[0];
                    //TwoNodes[0] = TwoNodes[1];
                    //TwoNodes[1] = temp;
                }

                if (temp.Right != null && temp.Right.Value == TwoNodes[0].Value)
                {
                    temp.Right = TwoNodes[1];
                    //Node temp = TwoNodes[0];
                    //TwoNodes[0] = TwoNodes[1];
                    //TwoNodes[1] = temp;
                }
                if (temp.Left != null && temp.Left.Value == TwoNodes[1].Value)
                {
                    temp.Left = TwoNodes[0];
                    //Node temp = TwoNodes[0];
                    //TwoNodes[0] = TwoNodes[1];
                    //TwoNodes[1] = temp;
                }
                if (temp.Right != null && temp.Right.Value == TwoNodes[1].Value)
                {
                    temp.Right = TwoNodes[0];
                    //Node temp = TwoNodes[0];
                    //TwoNodes[0] = TwoNodes[1];
                    //TwoNodes[1] = temp;
                }
                if (temp.Left != null) q.Enqueue(temp.Left);
                if (temp.Right != null) q.Enqueue(temp.Right);
            }
        }

        public void SwapTwoLeaves(Node root)
        {
            if (root == null) return;
            if (root.Left != null && root.Left.Value == TwoNodes[0].Value)
            {
                root.Left = TwoNodes[1];
                Node temp = TwoNodes[0];
                TwoNodes[0] = TwoNodes[1];
                TwoNodes[1] = temp;
            }

            if (root.Right != null && root.Right.Value == TwoNodes[0].Value)
            {
                root.Right = TwoNodes[1];
                Node temp = TwoNodes[0];
                TwoNodes[0] = TwoNodes[1];
                TwoNodes[1] = temp;
            }
            if (root.Left != null && root.Left.Value == TwoNodes[1].Value)
                root.Left = TwoNodes[0];

            if (root.Right != null && root.Right.Value == TwoNodes[1].Value)
                root.Right = TwoNodes[0];

            SwapTwoLeaves(root.Left);
            SwapTwoLeaves(root.Right);
        }

        public void GetTwoNodesArray(Node root, int a, int b)
        {
            if (root == null) return;
            if (root.Value == a) TwoNodes[0] = root;
            if (root.Value == b) TwoNodes[1] = root;
            GetTwoNodesArray(root.Left, a, b);
            GetTwoNodesArray(root.Right, a, b);
        }

        public void InOrderTraversal(Node root)
        {
            if (root == null) return;
            InOrderTraversal(root.Left);
            Console.WriteLine(root.Value);
            InOrderTraversal(root.Right);
        }

    }

    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
        public Node(int x)
        {
            Value = x;
        }
    }
}
