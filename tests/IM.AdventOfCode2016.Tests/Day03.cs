using System.Linq;
using FluentAssertions;
using IM.AdventOfCode2016.Day03;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day03 : TestBase
	{
		public Day03(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Puzzle1_CountValidTrianglesByRow()
		{
			var triangles = Inputs.Day3ParseByRow(Inputs.Day3);

			var valid = triangles.Count(x => x.IsValid);
			var invalid = triangles.Count(x => !x.IsValid);

			Output.WriteLine($"valid: {valid}, invalid: {invalid}"); // 917, 817

			valid.Should().Be(917);
			invalid.Should().Be(817);
			(valid + invalid).Should().Be(1734);
		}

		[Fact]
		public void Puzzle2_CountValidTrianglesByColumn()
		{
			var triangles = Inputs.Day3ParseByColumn(Inputs.Day3);

			var valid = triangles.Count(x => x.IsValid);
			var invalid = triangles.Count(x => !x.IsValid);

			Output.WriteLine($"valid: {valid}, invalid: {invalid}"); // 1649, 85

			valid.Should().Be(1649);
			invalid.Should().Be(85);
			(valid + invalid).Should().Be(1734);
		}

		[Theory]
		[InlineData(5, 10, 25)]
		[InlineData(25, 10, 5)]
		[InlineData(25, 5, 10)]
		public void GivenTestCaseWorks(long side1, long side2, long side3)
		{
			var triangle = new Triangle(side1, side2, side3);

			triangle.IsValid.Should().BeFalse();
		}
	}
}