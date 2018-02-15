using System;

namespace KTrees
{
    public class Tree
    {
        protected Node Root { get; set; }

        public void Print()
        {
            PrintRecursive(Root, "");
        }

        void Remove()
        {
            Root = null;
        }

        private static void PrintRecursive(Node node, string offset)
        {
            if (node == null)
            {
                Console.WriteLine($"{offset}<>");
                return;
            }

            Console.WriteLine($"{offset}{node.Key} ({node.HeightLeft}-{node.HeightRight})");

            var newOffset = offset + "\t";
            if (node.Right != null || node.Left != null)
            {
                PrintRecursive(node.Right, newOffset);
                PrintRecursive(node.Left, newOffset);
            }
        }

        #region Sherlok
        public Tree Mirror()
        {
            var mirrorTree = new Tree { Root = new Node { Key = Root.Key } };


            MirrorRecursive(mirrorTree.Root, Root);
            //Mi
            return mirrorTree;
        }

        private void MirrorRecursive(Node current, Node mirror)
        {
            if (current.Right == null)
                mirror.Left = null;
            else
            {
                mirror.Left = new Node { Key = current.Right.Key };
                MirrorRecursive(current.Right, mirror.Left);
            }

            if (current.Left == null)
                mirror.Right = null;
            else
            {
                mirror.Right = new Node { Key = current.Left.Key };
                MirrorRecursive(current.Left, mirror.Right);
            }
        }

        public bool IsSearchTree()
        {
            return IsSearchTree(Root);
        }

        private bool IsSearchTree(Node node)
        {
            if (node == null || node.Left == null && node.Right == null)
                return true;

            if (node.Left != null && node.Right != null)
            {
                if (node.Left.Key > node.Right.Key)
                    return false;
            }

            var leftGood = true;
            if (node.Left != null)
                leftGood = IsSearchTree(node.Left);

            var rightGood = true;
            if (node.Right != null)
                rightGood = IsSearchTree(node.Right);

            return leftGood && rightGood;
        }
        #endregion
    }
}
