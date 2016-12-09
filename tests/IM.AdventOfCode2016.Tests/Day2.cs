using System.Linq;
using System.Text;
using FluentAssertions;
using IM.AdventOfCode2016.Day2;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day2 : TestBase
	{
		private readonly Grid _puzzle1Grid;
		private readonly Grid _puzzle2Grid;

		public Day2(ITestOutputHelper output) : base(output)
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
				var finalInRow = row.Aggregate(_puzzle1Grid.Current, (node, direction) => _puzzle1Grid.Step(direction));
				resultBuilder.Append(finalInRow.Value);
			}

			var result = resultBuilder.ToString(); // "78985"

			Output.WriteLine($"Code to bathroom: {result}");

			result.Should().Be("78985");
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
				var current = row.Aggregate(_puzzle1Grid.Current, (node, direction) => _puzzle1Grid.Step(direction));
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
				var current = row.Aggregate(_puzzle2Grid.Current, (node, direction) => _puzzle2Grid.Step(direction));
				resultBuilder.Append(current.Value);
			}

			var result = resultBuilder.ToString();

			result.Should().Be(expectedCode);
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
