using System.Collections.Generic;
using System.Linq;

namespace IM.AdventOfCode2016.Day2
{
	public class Grid
	{
		public GridNode Current { get; private set; }

		public Grid(GridNode current)
		{
			Current = current;
		}

		public GridNode Step(Direction direction) => Current = Current.Next(direction);

		public GridNode Walk(IEnumerable<Direction> directions)
		{
			return directions.Aggregate(Current, (node, direction) => Step(direction));
		}
	}
}
