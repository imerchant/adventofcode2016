namespace IM.AdventOfCode2016
{
	public class Coord
	{
		public long X { get; private set; }
		public long Y { get; private set; }
		public FacingDirection Facing { get; private set; }

		public Coord(long x, long y, FacingDirection facing)
		{
			X = x;
			Y = y;
			Facing = facing;
		}

		public override string ToString()
		{
			return $"{Facing} ({X}, {Y})";
		}
	}
}