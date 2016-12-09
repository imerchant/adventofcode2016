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
	}
}
