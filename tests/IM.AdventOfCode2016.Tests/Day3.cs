using System.Linq;
using FluentAssertions;
using IM.AdventOfCode2016.Day3;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day3 : TestBase
	{
		public Day3(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Puzzle1_CountInvalidTriangles()
		{
			var triangles = Inputs.Day3Parse(Inputs.Day3);

			var valid = triangles.Count(x => x.IsValid);
			var invalid = triangles.Count(x => !x.IsValid);

			Output.WriteLine($"valid: {valid}, invalid: {invalid}");

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