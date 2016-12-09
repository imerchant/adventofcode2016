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
		private readonly Grid _grid;

		public Day2(ITestOutputHelper output) : base(output)
		{
			_grid = new Grid(Grid.GridNodes[5]);
		}

		[Fact]
		public void Puzzle1_UnlocktheBathroom()
		{
			var directions = Inputs.Day2Parse(Inputs.Day2);
			var resultBuilder = new StringBuilder(5);

			foreach (var row in directions)
			{
				var finalInRow = row.Aggregate(_grid.Current, (node, direction) => _grid.Step(direction));
				resultBuilder.Append(finalInRow.Value);
			}

			var result = resultBuilder.ToString(); // "78985"

			Output.WriteLine($"Code to bathroom: {result}");
		}

		[Fact]
		public void GivenTestCasesPassKeyCodeCheck()
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
				var current = row.Aggregate(_grid.Current, (node, direction) => _grid.Step(direction));
				resultBuilder.Append(current.Value);
			}

			var result = resultBuilder.ToString();

			result.Should().Be(expectedCode);
		}

		[Fact]
		public void DoingALoop()
		{
			var grid = new Grid(Grid.GridNodes[9]);
			var directions = new [] { Direction.L, Direction.U, Direction.R, Direction.D, Direction.L };

			var ending = directions.Aggregate(grid.Current, (node, direction) => node.Next(direction));

			ending.Value.Should().Be(8);
		}
	}
}
