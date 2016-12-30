using System;
using System.Collections.Generic;
using System.Linq;

namespace IM.AdventOfCode2016.Day01
{
	public static class Moving
	{
		public static State Move(this State state, Move action)
		{
			var newDirection = state.Facing.Turn(action.Direction);
			var newPosition = state.Position;
			var doublePosition = state.DoubleVisited;
			for (var k = 0; k < action.Distance; ++k)
			{
				newPosition = newPosition.Step(newDirection);
				if (!doublePosition.HasValue && !state.Visited.Add(newPosition))
				{
					Console.WriteLine($"First double located position is {newPosition} at distance {newPosition.TaxiCabDistance()}.");
					doublePosition = newPosition;
				}
				else
				{
					state.Visited.Add(newPosition);
				}
			}

			return new State(newPosition, newDirection, state.Visited, doublePosition);
		}

		public static State Travel(this State state, IEnumerable<Move> actions)
		{
			return actions.Aggregate(state, (current, move) => current.Move(move));
		}
	}
}