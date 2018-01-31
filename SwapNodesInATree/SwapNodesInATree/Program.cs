using System;
using System.Collections;
using System.Collections.Generic;

namespace SwapNodesInATree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree
            {
                Root = new Node
                {
                    Value = 2,
                    Left = new Node
                    {
                        Value = 4,
                        Left = new Node {Value = 3},
                        Right = new Node {Value = 10}
                    },
                    Right = new Node
                    {
                        Value = 9,
                        Right = new Node {Value = 1},
                        Left = new Node {Value = 5}
                    }
                }
            };

            Console.WriteLine("Before the swap");
            t.OutputTreeInOrder(t.Root);

            t.SwapWithBreadth(1, 3);

            Console.WriteLine("After the swap");
            t.OutputTreeInOrder(t.Root);

            Console.ReadLine();
        }
    }

    public class Tree
    {
        public Node Root;

        public void SwapWithBreadth(int a, int b)
        {
            Queue<Node> q = new Queue<Node>();
            Node nodeToSwapOne = null;
            Node nodeToSwapTwo = null;
            q.Enqueue(Root);
            while (q.Count > 0)
            {
                Node temp = q.Dequeue();
                if (temp.Left == null && temp.Right == null)
                {
                    if (temp.Value == a) nodeToSwapOne = temp;
                    if (temp.Value == b) nodeToSwapTwo = temp;
                }
                if (nodeToSwapOne != null && nodeToSwapTwo != null)
                {
                    Node actualSwap = nodeToSwapOne;
                    nodeToSwapOne = nodeToSwapTwo;
                    nodeToSwapTwo = actualSwap;
                    return;
                }
                if(temp.Left != null) q.Enqueue(temp.Left);
                if(temp.Right != null) q.Enqueue(temp.Right);
            }
        }

        public void OutputTreeInOrder(Node root)
        {
            if(root.Left != null) OutputTreeInOrder(root.Left);
            Console.WriteLine(root.Value);
            if(root.Right != null) OutputTreeInOrder(root.Right);
        }

        //public void SwapNodes(Node root, Node a, Node b)
        //{
        //    if(root.Value != a.Value || root.Value != b.Value && root.Left != null) SwapNodes(root.Left, a, b);
        //    if(root.Value != ) SwapNodes(root.Right, a, b);
        //}

    }

    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
    }
}
