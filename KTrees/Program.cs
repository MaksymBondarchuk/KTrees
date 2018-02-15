using System.Collections.Generic;

namespace KTrees
{
    internal static class Program
    {
        private static void Main()
        {
            var keys = new List<int> { 5, 3, 4, 6, 6, 2, 7, 1, 8 };

            var tree = new AvlTree();
            tree.Add(keys);
            tree.Print();
        }
    }
}
