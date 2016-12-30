using FluentAssertions;
using IM.AdventOfCode2016.Day09;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day09 : TestBase
	{
		public Day09(ITestOutputHelper output) : base(output)
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

		[Fact]
		public void Puzzle2_FindLengthWithV2Compression()
		{
			var input = Inputs.Day9;

			var length = TextCompression.DecompressedLengthV2(input); // 10943094568

			Output.WriteLine($"Decompressed length with V2: {length}");

			length.Should().Be(10943094568);
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

		[Theory]
		[InlineData("(3x3)XYZ", 9L)]
		[InlineData("X(8x2)(3x3)ABCY", 20L)]
		[InlineData("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920L)]
		[InlineData("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445L)]
		public void Puzzle2Examples_DetermineLengthCorrectly(string input, long expectedLength)
		{
			TextCompression.DecompressedLengthV2(input).Should().Be(expectedLength);
		}
	}
}