using System.Collections.Generic;
using FluentAssertions;
using IM.AdventOfCode2016.Day1;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day1 : TestBase
	{
		private readonly State _startingState;

		public Day1(ITestOutputHelper output) : base(output)
		{
			_startingState = new State(0, 0, FacingDirection.N, new HashSet<Point>());
		}

		[Fact]
		public void Puzzle1_FindDistanceAfterInstructions()
		{
			var moves = Inputs.Day1Parse(Inputs.Day1);

			Output.WriteLine("number of moves: {0}", moves.Count);

			var ending = _startingState.Travel(moves);

			Output.WriteObject(ending.Position);

			var distance = ending.TaxiCabDistance; // 246

			Output.WriteLine("distance from start to end: {0}", distance);

			distance.Should().Be(246);
		}

		[Fact]
		public void Puzzle2_FindFirstDoubleVisitedLocation()
		{
			var moves = Inputs.Day1Parse(Inputs.Day1);
			var state = _startingState;

			foreach (var move in moves)
			{
				state = state.Move(move);
				if (state.DoubleVisited.HasValue)
					break;
			}

			state.DoubleVisited.Should().NotBeNull();
			var distance = state.DoubleVisited.Value.TaxiCabDistance();
			Output.WriteLine($"First double located position is {state.DoubleVisited} at distance {distance}."); // 124

			distance.Should().Be(124);
		}

		[Theory]
		[InlineData("R2, L3", 5)]
		[InlineData("R2, R2, R2", 2)]
		[InlineData("R5, L5, R5, R3", 12)]
		public void GivenTestCasesPassDistanceCheck(string moveString, int expectedDistance)
		{
			var moves = Inputs.Day1Parse(moveString);

			var endingState = _startingState.Travel(moves);

			endingState.TaxiCabDistance.Should().Be(expectedDistance);
		}

		[Theory]
		[InlineData(FacingDirection.N, FacingDirection.E)]
		[InlineData(FacingDirection.E, FacingDirection.S)]
		[InlineData(FacingDirection.S, FacingDirection.W)]
		[InlineData(FacingDirection.W, FacingDirection.N)]
		public void TurningRightCyclesCorrectly(FacingDirection starting, FacingDirection expected)
		{
			starting.Turn(TurningDirection.R).Should().Be(expected);
		}

		[Theory]
		[InlineData(FacingDirection.N, FacingDirection.W)]
		[InlineData(FacingDirection.E, FacingDirection.N)]
		[InlineData(FacingDirection.S, FacingDirection.E)]
		[InlineData(FacingDirection.W, FacingDirection.S)]
		public void TurningLeftCyclesCorrectly(FacingDirection starting, FacingDirection expected)
		{
			starting.Turn(TurningDirection.L).Should().Be(expected);
		}

		[Fact]
		public void TranslatingNFrom00OnlyIncrementsY()
		{
			var expected = new Point(0, 1);
			var actual = new Point(0, 0).Step(FacingDirection.N);
			actual.ShouldBeEquivalentTo(expected);
		}
	}
}