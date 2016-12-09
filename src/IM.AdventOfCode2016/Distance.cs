using System;

namespace IM.AdventOfCode2016
{
	public static class Distance
	{
		public static long TaxiCabDistance(this Point point)
		{
			return Math.Abs(point.X) + Math.Abs(point.Y);
		}
	}
}