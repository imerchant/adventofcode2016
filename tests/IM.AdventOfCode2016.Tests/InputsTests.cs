using System.Collections.Generic;
using FluentAssertions;
using IM.AdventOfCode2016.Day1;
using IM.AdventOfCode2016.Day2;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class InputsTests : TestBase
	{
		private readonly List<Move> R2L3;
		private readonly Direction[][] _day2ExampleExpected;

		public InputsTests(ITestOutputHelper output) : base(output)
		{
			R2L3 = new List<Move>
			{
				new Move(TurningDirection.R, 2),
				new Move(TurningDirection.L, 3)
			};

			_day2ExampleExpected = new []
			{
				new [] { Direction.U, Direction.L, Direction.L },
				new [] { Direction.R, Direction.R, Direction.D, Direction.D, Direction.D },
				new [] { Direction.L, Direction.U, Direction.R, Direction.D, Direction.L },
				new [] { Direction.U, Direction.U, Direction.U, Direction.U, Direction.D }
			};
		}

		[Fact]
		public void Day1Parse_CreatesCorrectMoveList()
		{
			const string moves = "R2, L3";

			var actual = Inputs.Day1Parse(moves);

			actual.ShouldBeEquivalentTo(R2L3);
		}

		[Fact]
		public void Day2Parse_CreatesCorrectMoveCollection()
		{
			const string moves = @"ULL
RRDDD
LURDL
UUUUD";

			var actual = Inputs.Day2Parse(moves);

			actual.ShouldBeEquivalentTo(_day2ExampleExpected);
		}

		[Fact]
		public void Day3_RetrieveWorks()
		{
			var day3 = Inputs.Day3;
			day3.Should().NotBeNullOrEmpty();
		}

		[Fact]
		public void Day3ParseByRowWorks()
		{
			var triangles = Inputs.Day3ParseByRow(Inputs.Day3);
			triangles.Should().HaveCount(1734);
		}

		[Fact]
		public void Day3ParseByColumnWorks()
		{
			var triangles = Inputs.Day3ParseByColumn(Inputs.Day3);
			triangles.Should().HaveCount(1734);
		}
	}
}
