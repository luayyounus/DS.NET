using System;

namespace SumLeaves
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");

            Node A = new Node(8);
            Node B = new Node(4);
            Node C = new Node(6);
            Node D = new Node(9);
            //Node E = new Node(3);
            //Node F = new Node(5);
            Node G = new Node(7);

            A.Left = B;
            A.Right = C;
            B.Left = D;
            //B.Right = E;
            //C.Left = F;
            C.Right = G;

            Console.WriteLine("          A          ");
            Console.WriteLine("         / \\        ");
            Console.WriteLine("        B   C        ");
            Console.WriteLine("       / \\ / \\     ");
            Console.WriteLine("      D  E F  G      ");

            Console.WriteLine("\nA = 8, B = 4, C = 6, D = 9, E = 3, F = 5, G = 7");
            Console.WriteLine("\nAdding all leaf nodes should be 24.\n");

            Console.WriteLine("AddLeaves(A): " + AddLeaves(A));

            Console.ReadLine();
        }

        private static int AddLeaves(Node root)
        {
            int temp = 0;
            if (root.Left != null && root.Right != null)
            {
                temp += AddLeaves(root.Left);
                temp += AddLeaves(root.Right);
            }
            else return root.Value;
            return temp;
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
