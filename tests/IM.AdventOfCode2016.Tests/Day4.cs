using System.Linq;
using FluentAssertions;
using IM.AdventOfCode2016.Day4;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day4 : TestBase
	{
		public Day4(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Puzzle1_SumSectorIdsOfRealRooms()
		{
			var rooms = Inputs.Day4Parse(Inputs.Day4);

			var total = rooms.Sum(room => room.Value); // 409147

			Output.WriteLine($"Sum of sector Ids of valid rooms: {total}");

			total.Should().Be(409147);
		}

		[Theory]
		[InlineData("aaaaa-bbb-z-y-x", "abxyz")]
		[InlineData("a-b-c-d-e-f-g-h", "abcde")]
		[InlineData("not-a-real-room", "oarel")]
		public void ChecksumsGenerateCorrectly(string name, string expectedChecksum)
		{
			name.Checksum().Should().Be(expectedChecksum);
		}

		[Fact]
		public void ChecksumDoesNotMatchGiven()
		{
			"totally-real-room".Checksum().Should().NotBe("decoy");
		}

		[Fact]
		public void GivenTestCaseWorks()
		{
			const string exampleInput = @"aaaaa-bbb-z-y-x-123[abxyz]
a-b-c-d-e-f-g-h-987[abcde]
not-a-real-room-404[oarel]
totally-real-room-200[decoy]";

			var rooms = Inputs.Day4Parse(exampleInput);

			var total = rooms.Sum(room => room.Value);

			total.Should().Be(1514);
		}
	}
}