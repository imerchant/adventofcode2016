using System.Reflection;

namespace IM.AdventOfCode2016
{
	public struct Point
	{
		public long X { get; private set; }
		public long Y { get; private set; }

		public Point(long x, long y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"({X}, {Y})";
		}
	}
}