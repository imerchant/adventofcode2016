using System.Collections.Generic;
using System.Linq;

namespace IM.AdventOfCode2016
{
	public static class Moving
	{
		public static Coord Move(this Coord location, Move action)
		{
			var facing = location.Turn(action.Direction);
			var x = location.TranslateX(facing, action.Distance);
			var y = location.TranslateY(facing, action.Distance);
			return new Coord(x, y, facing);
		}

		public static Coord Travel(this Coord location, IEnumerable<Move> actions)
		{
			return actions.Aggregate(location, (coord, move) => coord.Move(move));
		}
	}
}