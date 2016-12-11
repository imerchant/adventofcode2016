using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.AdventOfCode2016.Day3
{
	public class Triangle
	{
		private readonly long[] _sides;

		public long Side1 => _sides.HasAny() ?_sides[0] : 0L;
		public long Side2 => _sides.HasAny() ?_sides[1] : 0L;
		public long Side3 => _sides.HasAny() ?_sides[2] : 0L;

		public bool IsValid => Side1 + Side2 > Side3;

		public Triangle(params long[] sides)
		{
			_sides = sides.OrderBy(x => x).ToArray();
		}
	}
}
