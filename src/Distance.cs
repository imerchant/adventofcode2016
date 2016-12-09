using System;

namespace IM.AdventOfCode2016
{
	public static class Distance
	{
		public static long TaxiCabDistance(this Coord c1, Coord c2)
		{
			return Math.Abs(c1.X - c2.X) + Math.Abs(c1.Y - c2.Y);
		}
	}
}