using FluentAssertions;
using IM.AdventOfCode2016.Day9;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day9 : TestBase
	{
		public Day9(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Puzzle1_DecompressedMessageLength()
		{
			var input = Inputs.Day9;

			var decompressed = TextCompression.Decompress(input);
			var length = decompressed.Length; // 99145

			Output.WriteLine($"Decompressed: {decompressed}");
			Output.WriteLine($"Length: {length}");

			length.Should().Be(99145);
		}

		[Theory]
		[InlineData("ADVENT", "ADVENT", 6)]
		[InlineData("A(1x5)BC", "ABBBBBC", 7)]
		[InlineData("(3x3)XYZ", "XYZXYZXYZ", 9)]
		[InlineData("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG", 11)]
		[InlineData("(6x1)(1x3)A", "(1x3)A", 6)]
		[InlineData("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY", 18)]
		public void Puzzle1Examples_DecompressCorrectly(string input, string expected, int expectedLength)
		{
			TextCompression.Decompress(input).Should()
				.HaveLength(expectedLength)
				.And.Be(expected);
		}
	}
}