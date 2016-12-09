using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day1 : TestBase
	{
		private static readonly State StartingState = new State(0, 0, FacingDirection.N, new HashSet<Point>());
		private const string RawInstructions = @"R2, L3, R2, R4, L2, L1, R2, R4, R1, L4, L5, R5, R5, R2, R2, R1, L2, L3, L2, L1, R3, L5, R187, R1, R4, L1, R5, L3, L4, R50, L4, R2, R70, L3, L2, R4, R3, R194, L3, L4, L4, L3, L4, R4, R5, L1, L5, L4, R1, L2, R4, L5, L3, R4, L5, L5, R5, R3, R5, L2, L4, R4, L1, R3, R1, L1, L2, R2, R2, L3, R3, R2, R5, R2, R5, L3, R2, L5, R1, R2, R2, L4, L5, L1, L4, R4, R3, R1, R2, L1, L2, R4, R5, L2, R3, L4, L5, L5, L4, R4, L2, R1, R1, L2, L3, L2, R2, L4, R3, R2, L1, L3, L2, L4, L4, R2, L3, L3, R2, L4, L3, R4, R3, L2, L1, L4, R4, R2, L4, L4, L5, L1, R2, L5, L2, L3, R2, L2";

		public Day1(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Puzzle1_FindDistanceAfterInstructions()
		{
			var moves = Utilities.ParseMoves(RawInstructions);

			Output.WriteLine("number of moves: {0}", moves.Count);

			var ending = StartingState.Travel(moves);

			Output.WriteObject(ending.Position);

			var distance = ending.TaxiCabDistance; // 246

			Output.WriteLine("distance from start to end: {0}", distance);

			distance.Should().Be(246);
		}

		[Fact]
		public void Puzzle2_FindFirstDoubleVisitedLocation()
		{
			var moves = Utilities.ParseMoves(RawInstructions);
			var state = StartingState;

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
			var moves = Utilities.ParseMoves(moveString);

			var endingState = StartingState.Travel(moves);

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