using System.Collections.Generic;

namespace KTrees
{
    public class BalancedTree: Tree
    {
        public void Add(IEnumerable<int> keys)
        {
            foreach (var key in keys)
            {
                Add(Root, key);
            }
        }

        private void Add(Node location, int key)
        {
            if (Root == null)
            {
                Root = new Node { Key = key };
                return;
            }

            if (0 <= location.Diff)
            {
                location.Diff--;
                if (location.Left == null)
                    location.Left = new Node { Key = key };
                else
                    Add(location.Left, key);
            }
            else
            {
                location.Diff++;
                if (location.Right == null)
                    location.Right = new Node { Key = key };
                else
                    Add(location.Right, key);
            }
        }
    }
}
