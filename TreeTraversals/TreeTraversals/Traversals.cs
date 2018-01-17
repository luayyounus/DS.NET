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
            if (root.Left != null)
                PostOrderTraversal(root.Left);
            if (root.Right != null)
                PostOrderTraversal(root.Right);
        }

        public void InOrderTraversal(TNode root)
        {
            if (root == null) return;
            if (root.Left != null)
                InOrderTraversal(root.Left);
            Console.WriteLine(root.Val);
            if (root.Right != null)
                InOrderTraversal(root.Right);
        }
        public void PostOrderTraversal(TNode root)
        {
            if (root == null) return;
            if (root.Left != null)
                PostOrderTraversal(root.Left);
            if (root.Right != null)
                PostOrderTraversal(root.Right);
            Console.WriteLine(root.Val);
        }
    }
}
