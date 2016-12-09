using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IM.AdventOfCode2016.Day2
{
	public class Grid
	{
		public GridNode Current { get; private set; }

		private static readonly Lazy<Dictionary<int, GridNode>> _gridNodes = new Lazy<Dictionary<int, GridNode>>(GetGrid);
		public static Dictionary<int, GridNode> GridNodes => _gridNodes.Value;

		public Grid(GridNode current)
		{
			Current = current;
		}

		public GridNode Step(Direction direction) => Current = Current.Next(direction);

		private static Dictionary<int, GridNode> GetGrid()
		{
			var nodes = Enumerable.Range(1, 9).ToDictionary(x => x, x => new GridNode(x));

			nodes[1].Neighbors[Direction.R] = nodes[2];
			nodes[1].Neighbors[Direction.D] = nodes[4];

			nodes[2].Neighbors[Direction.L] = nodes[1];
			nodes[2].Neighbors[Direction.R] = nodes[3];
			nodes[2].Neighbors[Direction.D] = nodes[5];

			nodes[3].Neighbors[Direction.L] = nodes[2];
			nodes[3].Neighbors[Direction.D] = nodes[6];

			nodes[4].Neighbors[Direction.U] = nodes[1];
			nodes[4].Neighbors[Direction.R] = nodes[5];
			nodes[4].Neighbors[Direction.D] = nodes[7];

			nodes[5].Neighbors[Direction.U] = nodes[2];
			nodes[5].Neighbors[Direction.R] = nodes[6];
			nodes[5].Neighbors[Direction.D] = nodes[8];
			nodes[5].Neighbors[Direction.L] = nodes[4];

			nodes[6].Neighbors[Direction.U] = nodes[3];
			nodes[6].Neighbors[Direction.D] = nodes[9];
			nodes[6].Neighbors[Direction.L] = nodes[5];

			nodes[7].Neighbors[Direction.U] = nodes[4];
			nodes[7].Neighbors[Direction.R] = nodes[8];

			nodes[8].Neighbors[Direction.U] = nodes[5];
			nodes[8].Neighbors[Direction.R] = nodes[9];
			nodes[8].Neighbors[Direction.L] = nodes[7];

			nodes[9].Neighbors[Direction.U] = nodes[6];
			nodes[9].Neighbors[Direction.L] = nodes[8];

			return nodes;
		}
	}

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

	public enum Direction
	{
		U, R, D, L
	}
}
