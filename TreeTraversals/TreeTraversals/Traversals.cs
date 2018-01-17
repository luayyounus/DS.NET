using System;
using System.Collections.Generic;
using System.Text;

namespace TreeTraversals
{
    public class Traversals
    {
        public TNode Root = null;

        public void PreOrderTraversal(TNode root)
        {
            if (root == null) return;
            Console.WriteLine(root.Val);
            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
        }

        public void InOrderTraversal(TNode root)
        {
            if (root == null) return;
            InOrderTraversal(root.Left);
            Console.WriteLine(root.Val);
            InOrderTraversal(root.Right);
        }
        public void PostOrderTraversal(TNode root)
        {
            if (root == null) return;
            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
            Console.WriteLine(root.Val);
        }
    }
}
