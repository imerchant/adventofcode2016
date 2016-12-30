using System.Collections.Generic;

namespace IM.AdventOfCode2016.Day01
{
	public static class Translating
	{
		private static readonly Dictionary<FacingDirection, Point> Steps = new Dictionary<FacingDirection, Point>
		{
			{ FacingDirection.N, new Point(0, 1) },
			{ FacingDirection.E, new Point(1, 0) },
			{ FacingDirection.S, new Point(0, -1) },
			{ FacingDirection.W, new Point(-1, 0) }
		};

		public static Point Step(this Point current, FacingDirection direction)
		{
			var step = Steps[direction];
			return new Point(current.X + step.X, current.Y + step.Y);
		}
	}
}