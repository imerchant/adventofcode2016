using System.Linq;
using System.Text;
using FluentAssertions;
using IM.AdventOfCode2016.Day02;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day02 : TestBase
	{
		private readonly Grid _puzzle1Grid;
		private readonly Grid _puzzle2Grid;

		public Day02(ITestOutputHelper output) : base(output)
		{
			_puzzle1Grid = new Grid(Grids.Puzzle1Grid[5]);
			_puzzle2Grid = new Grid(Grids.Puzzle2Grid[5]);
		}

		[Fact]
		public void Puzzle1_UnlocktheBathroom()
		{
			var directions = Inputs.Day2Parse(Inputs.Day2);
			var resultBuilder = new StringBuilder(5);

			foreach (var row in directions)
			{
				var finalInRow = _puzzle1Grid.Walk(row);
				resultBuilder.Append(finalInRow.Value);
			}

			var result = resultBuilder.ToString(); // "78985"

			Output.WriteLine($"Code to bathroom: {result}");

			result.Should().Be("78985");
		}

		[Fact]
		public void Puzzle2_UnlockComplexBathroom()
		{
			var directions = Inputs.Day2Parse(Inputs.Day2);
			var resultBuilder = new StringBuilder(5);

			foreach (var row in directions)
			{
				var finalInRow = _puzzle2Grid.Walk(row);
				resultBuilder.Append($"{finalInRow.Value:X}");
			}

			var result = resultBuilder.ToString(); // "57DD8"

			Output.WriteLine($"Code to bathroom: {result}");

			result.Should().Be("57DD8");
		}

		[Fact]
		public void GivenTestCasesPassKeyCodeCheckForGrid1()
		{
			const string moves = @"ULL
RRDDD
LURDL
UUUUD";
			const string expectedCode = "1985";

			var directions = Inputs.Day2Parse(moves);
			var resultBuilder = new StringBuilder(5);

			foreach (var row in directions)
			{
				var current = _puzzle1Grid.Walk(row);
				resultBuilder.Append(current.Value);
			}

			var result = resultBuilder.ToString();

			result.Should().Be(expectedCode);
		}

		[Fact]
		public void GivenTestCasesPassKeyCodeCheckForGrid2()
		{
			const string moves = @"ULL
RRDDD
LURDL
UUUUD";
			const string expectedCode = "5DB3";

			var directions = Inputs.Day2Parse(moves);
			var resultBuilder = new StringBuilder(5);

			foreach (var row in directions)
			{
				var current = _puzzle2Grid.Walk(row);
				resultBuilder.Append($"{current.Value:X}");
			}

			var result = resultBuilder.ToString();

			result.Should().Be(expectedCode);
		}

		[Theory]
		[InlineData(1, 1, 1, 3, 1)]
		[InlineData(2, 2, 3, 6, 2)]
		[InlineData(3, 1, 4, 7, 2)]
		[InlineData(4, 4, 4, 8, 3)]
		[InlineData(5, 5, 6, 5, 5)]
		[InlineData(6, 2, 7, 10, 5)]
		[InlineData(7, 3, 8, 11, 6)]
		[InlineData(8, 4, 9, 12, 7)]
		[InlineData(9, 9, 9, 9, 8)]
		[InlineData(10, 6, 11, 10, 10)] // A
		[InlineData(11, 7, 12, 13, 10)] // B
		[InlineData(12, 8, 12, 12, 11)] // C
		[InlineData(13, 11, 13, 13, 13)] // D
		public void Puzzle2GridIsDefinedCorrectly(int currentNode, int upTarget, int rightTarget, int downTarget, int leftTarget)
		{
			var current = Grids.Puzzle2Grid[currentNode];

			current.Next(Direction.U).Value.Should().Be(upTarget);
			current.Next(Direction.R).Value.Should().Be(rightTarget);
			current.Next(Direction.D).Value.Should().Be(downTarget);
			current.Next(Direction.L).Value.Should().Be(leftTarget);
		}

		[Fact]
		public void DoingALoop()
		{
			var grid = new Grid(Grids.Puzzle1Grid[9]);
			var directions = new [] { Direction.L, Direction.U, Direction.R, Direction.D, Direction.L };

			var ending = directions.Aggregate(grid.Current, (node, direction) => node.Next(direction));

			ending.Value.Should().Be(8);
		}
	}
}
