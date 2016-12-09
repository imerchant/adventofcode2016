using System;
using System.Collections.Generic;
using System.Linq;

namespace IM.AdventOfCode2016
{
	public static class Turning
	{
		private static readonly LinkedList<FacingDirection> Directions;
		private static readonly Dictionary<TurningDirection, Func<LinkedListNode<FacingDirection>, FacingDirection>> TurningStrategies = new Dictionary<TurningDirection, Func<LinkedListNode<FacingDirection>, FacingDirection>>
		{
			{ TurningDirection.L, node => node.Previous?.Value ?? FacingDirection.W },
			{ TurningDirection.R, node => node.Next?.Value ?? FacingDirection.N }
		};

		static Turning()
		{
			var directions = Enum.GetValues(typeof(FacingDirection)).Cast<FacingDirection>();
			Directions = new LinkedList<FacingDirection>(directions);
		}

		public static FacingDirection Turn(this FacingDirection current, TurningDirection turnTo)
		{
			return TurningStrategies[turnTo](Directions.Find(current));
		}
	}
}