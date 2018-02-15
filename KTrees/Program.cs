using System.Collections.Generic;

namespace KTrees
{
    internal static class Program
    {
        private static void Main()
        {
            var keys = new List<int> { 5, 3, 4, 6, 2, 7, 1, 8 };

            var tree = new SearchTree();
            tree.Add(keys);
            tree.Print();
            tree.PrintInfix();
        }
    }
}
