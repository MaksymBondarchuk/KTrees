using System;
using System.Collections.Generic;

namespace KTrees
{
    public class AvlTree: Tree
    {
        public void Add(IEnumerable<int> keys)
        {
            foreach (var key in keys)
            {
                Add(Root, null, key);
            }
        }

        private void Add(Node location, Node parent, int key)
        {
            if (Root == null)
            {
                Root = new Node { Key = key };
                return;
            }

            if (key < location.Key)
            {
                if (location.Left == null)
                    location.Left = new Node { Key = key };
                else
                    Add(location.Left, location, key);

                location.HeightLeft = Math.Max(location.Left.HeightLeft, location.Left.HeightRight) + 1;
                if (NodeNeedBalance(location))
                    RotateRight(location, parent);
            }
            else
            {
                if (location.Right == null)
                    location.Right = new Node { Key = key };
                else
                    Add(location.Right, location, key);

                location.HeightRight = Math.Max(location.Right.HeightLeft, location.Right.HeightRight) + 1;
                //location.HeightRight++;
                if (NodeNeedBalance(location))
                    RotateLeft(location, parent);
            }

        }

        private static bool NodeNeedBalance(Node location)
        {
            return NeedLeftBalance(location) || NeedRightBalance(location);
        }

        private static bool NeedLeftBalance(Node location)
        {
            return location != null && location.HeightRight - location.HeightLeft >= 2;
        }

        private static bool NeedRightBalance(Node location)
        {
            return location != null && location.HeightLeft - location.HeightRight >= 2;
        }

        private void RotateLeft(Node location, Node parent)
        {
            Print();
            var a = location;
            var b = location.Right;
            var c = b.Left;
            var r = b.Right;

            // Мале ліве обертання
            if (b.HeightLeft < b.HeightRight)
            {
                a.Right = c;
                b.Left = a;
                b.Right = r;

                a.UpdateHeights();
                b.UpdateHeights();

                if (parent == null)
                    Root = b;
                else
                    parent.Right = b;
            }
            else // Велике ліве обертання
            {
                var m = c.Left;
                var n = c.Right;

                a.Right = m;
                b.Left = n;
                c.Left = a;
                c.Right = b;

                a.UpdateHeights();
                b.UpdateHeights();
                c.UpdateHeights();

                if (parent == null)
                    Root = c;
                else
                    parent.Right = c;
            }

            Console.WriteLine($"Balanced for {location.Key}");
            Print();
        }

        private void RotateRight(Node location, Node parent)
        {
            Print();
            var a = location;
            var b = location.Left;
            var l = b.Left;
            var c = b.Right;

            // Мале праве обертання
            if (b.HeightRight < b.HeightLeft)
            {
                b.Right = a;
                b.Left = l;
                a.Left = c;

                a.UpdateHeights();
                b.UpdateHeights();

                if (parent == null)
                    Root = b;
                else
                    parent.Left = b;
            }
            else // Велике праве обертання
            {
                var m = c.Left;
                var n = c.Right;

                a.Left = n;
                b.Right = m;
                c.Left = b;
                c.Right = a;

                a.UpdateHeights();
                b.UpdateHeights();
                c.UpdateHeights();

                if (parent == null)
                    Root = c;
                else
                    parent.Left = c;
            }

            Console.WriteLine($"Balanced for {location.Key}");
            Print();
        }
    }
}
