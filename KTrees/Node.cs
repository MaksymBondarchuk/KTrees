using System;

namespace KTrees
{
	public class Node
	{
		public int Key { get; set; }

		public Node Left { get; set; }
		public Node Right { get; set; }

	    public int HeightLeft { get; set; }
	    public int HeightRight { get; set; }

        public void UpdateHeights()
	    {
	        if (Left == null)
	            HeightLeft = 0;
	        else
	            HeightLeft = Math.Max(Left.HeightLeft, Left.HeightRight) + 1;

	        if (Right == null)
	            HeightRight = 0;
	        else
	            HeightRight = Math.Max(Right.HeightLeft, Right.HeightRight) + 1;
	    }
    }
}
