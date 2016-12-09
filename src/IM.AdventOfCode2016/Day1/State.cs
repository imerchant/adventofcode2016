using System.Collections.Generic;

namespace IM.AdventOfCode2016.Day1
{
	public class State
	{
		public Point Position { get; private set; }
		public FacingDirection Facing { get; private set; }
		public HashSet<Point> Visited { get; private set; }
		public Point? DoubleVisited { get; private set; }
		public long TaxiCabDistance => Position.TaxiCabDistance();

		public State(long x, long y, FacingDirection facing, HashSet<Point> visited, Point? doubleVisited = null) : this(new Point(x,y), facing, visited, doubleVisited)
		{
		}

		public State(Point position, FacingDirection facing, HashSet<Point> visited, Point? doubleVisited = null)
		{
			Position = position;
			Facing = facing;
			Visited = visited;
			DoubleVisited = doubleVisited;
		}
	}
}