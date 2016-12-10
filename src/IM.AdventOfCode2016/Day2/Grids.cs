using System;
using System.Collections.Generic;
using System.Linq;

namespace IM.AdventOfCode2016.Day2
{
	public static class Grids
	{
		private static readonly Lazy<Dictionary<int, GridNode>> _puzzle1Grid = new Lazy<Dictionary<int, GridNode>>(GetPuzzle1Grid);
		public static Dictionary<int, GridNode> Puzzle1Grid => _puzzle1Grid.Value;

		private static Dictionary<int, GridNode> GetPuzzle1Grid()
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

		private static readonly Lazy<Dictionary<int, GridNode>> _puzzle2Grid = new Lazy<Dictionary<int, GridNode>>(GetPuzzle2Grid);
		public static Dictionary<int, GridNode> Puzzle2Grid => _puzzle2Grid.Value;

		private static Dictionary<int, GridNode> GetPuzzle2Grid()
		{
			var nodes = Enumerable.Range(1, 13).ToDictionary(x => x, x => new GridNode(x));

			nodes[1]
				.Down(nodes[3]);

			nodes[2]
				.Right(nodes[3])
				.Down(nodes[6]);

			nodes[3]
				.Up(nodes[1])
				.Right(nodes[4])
				.Down(nodes[7])
				.Left(nodes[2]);

			nodes[4]
				.Down(nodes[8])
				.Left(nodes[3]);

			nodes[5]
				.Right(nodes[6]);

			nodes[6]
				.Up(nodes[2])
				.Right(nodes[7])
				.Down(nodes[10])
				.Left(nodes[5]);

			nodes[7]
				.Up(nodes[3])
				.Right(nodes[8])
				.Down(nodes[11])
				.Left(nodes[6]);

			nodes[8]
				.Up(nodes[4])
				.Right(nodes[9])
				.Down(nodes[12])
				.Left(nodes[7]);

			nodes[9]
				.Left(nodes[8]);

			nodes[10] // A
				.Up(nodes[6])
				.Right(nodes[11]);

			nodes[11] // B
				.Up(nodes[7])
				.Right(nodes[12])
				.Down(nodes[13])
				.Left(nodes[10]);

			nodes[12] // C
				.Up(nodes[8])
				.Left(nodes[11]);

			nodes[13] // D
				.Up(nodes[11]);

			return nodes;
		}
	}
}