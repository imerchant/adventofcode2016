using System.Collections.Generic;

namespace IM.AdventOfCode2016.Day2
{
	public struct GridNode
	{
		public Dictionary<Direction, GridNode> Neighbors { get; }
		public int Value { get; }

		public GridNode(int value)
		{
			Value = value;
			Neighbors = new Dictionary<Direction, GridNode>(4);
		}

		public GridNode Next(Direction direction)
		{
			return Neighbors.GetValueOrDefault(direction, this);
		}
	}
}