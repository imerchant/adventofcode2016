using System.Collections.Generic;

namespace IM.AdventOfCode2016
{
	public static class Translating
	{
		private static readonly Dictionary<FacingDirection, int> XMultipliers = new Dictionary<FacingDirection, int>
		{
			{ FacingDirection.N, 0 },
			{ FacingDirection.E, 1 },
			{ FacingDirection.S, 0 },
			{ FacingDirection.W, -1 }
		};

		private static readonly Dictionary<FacingDirection, int> YMultipliers = new Dictionary<FacingDirection, int>
		{
			{ FacingDirection.N, 1 },
			{ FacingDirection.E, 0 },
			{ FacingDirection.S, -1 },
			{ FacingDirection.W, 0 }
		};

		public static long TranslateX(this Coord coord, FacingDirection facing, long distance)
		{
			var multi = XMultipliers[facing];
			return coord.X + multi*distance;
		}

		public static long TranslateY(this Coord coord, FacingDirection facing, long distance)
		{
			var multi = YMultipliers[facing];
			return coord.Y + multi*distance;
		}
	}
}