using System;

namespace MammalTreeBuilding
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node();
            Node left = new Node();
            Node right = new Node();
            root.Left = left;
            root.Right = right;

            root.Value = "Is it a mammal?";
            root.Left.Value = "4 Legs?";
            root.Right.Value = "Under water?";

            MammalTree.Root = root;
            while (true)
            {
                MammalTree.Play(MammalTree.Root);
            }
        }
    }

    internal static class MammalTree
    {
        public static Node Root = null;
        public static void Play(Node root)
        {
            Console.WriteLine("------- Start ------");
            Console.WriteLine(root.Value);
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                Console.WriteLine("You won! The animal is {0}", root.Left.Value);
                Play(Root);
                return;
            }
            if (input == "n")
            {
                if (root.Right == null)
                {
                    Console.WriteLine("Enter your question");
                    string q = Console.ReadLine();

                    Console.WriteLine("Enter animal name");
                    string a = Console.ReadLine();

                    Node question = new Node();
                    Node animal = new Node();

                    question.Value = q;
                    animal.Value = a;

                    root.Right = question;
                    root.Right.Left = animal;
                }
                else
                {
                    Play(root.Right);
                }
            }
        }
    }

    internal class Node
    {
        public Node Left;
        public Node Right;
        public string Value;
    }
}
