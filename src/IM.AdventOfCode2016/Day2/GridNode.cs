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

		public GridNode Up(GridNode node)
		{
			Neighbors[Direction.U] = node;
			return this;
		}

		public GridNode Right(GridNode node)
		{
			Neighbors[Direction.R] = node;
			return this;
		}

		public GridNode Down(GridNode node)
		{
			Neighbors[Direction.D] = node;
			return this;
		}

		public GridNode Left(GridNode node)
		{
			Neighbors[Direction.L] = node;
			return this;
		}
	}
}