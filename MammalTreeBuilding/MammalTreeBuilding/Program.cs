using System;

namespace MammalTreeBuilding
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node();
            root.Value = "Is it a mammal?";
            root.Left = new Node() {Value = "Shark?"};

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
            Console.WriteLine(root.Value);
            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.WriteLine(root.Left.Value);
                input = Console.ReadLine();
                if (input == "y")
                {
                    Play(Root);
                }
                else
                {
                    if (root.Left.Right == null)
                    {
                        AddQuestionAndAnswer(root.Left);
                    }
                    else
                    {
                        Play(root.Left.Right);
                    }
                }
            } else if (input == "n")
            {
                if (root.Right == null)
                {
                    AddQuestionAndAnswer(root);
                }
                else
                {
                    Play(root.Right);
                }
            }
        }

        public static void AddQuestionAndAnswer(Node node)
        {
            Console.WriteLine("Enter your question");
            string q = Console.ReadLine();

            Console.WriteLine("Enter animal name");
            string a = Console.ReadLine();

            Node question = new Node() {Value = q};
            Node animal = new Node() {Value = a};

            node.Right = question;
            node.Right.Left = animal;
        }
    }

    internal class Node
    {
        public Node Left;
        public Node Right;
        public string Value;
    }
}
