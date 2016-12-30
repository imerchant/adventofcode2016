using System.Linq;
using FluentAssertions;
using IM.AdventOfCode2016.Day04;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day04 : TestBase
	{
		public Day04(ITestOutputHelper output) : base(output)
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

		[Fact]
		public void Puzzle2_FindNorthPoleObjects()
		{
			var rooms = Inputs.Day4Parse(Inputs.Day4).Where(room => room.IsReal && room.Room.Name.Contains("storage")).ToList();

			Output.WriteLine($"number of real rooms: {rooms.Count}");
			foreach (var room in rooms)
			{
				Output.WriteLine($"{room.Room.Name} - {room.Room.Id}"); // northpole object storage - 991
			}
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
		public void Puzzle1_GivenTestCaseWorks()
		{
			const string exampleInput = @"aaaaa-bbb-z-y-x-123[abxyz]
a-b-c-d-e-f-g-h-987[abcde]
not-a-real-room-404[oarel]
totally-real-room-200[decoy]";

			var rooms = Inputs.Day4Parse(exampleInput);

			var total = rooms.Sum(room => room.Value);

			total.Should().Be(1514);
		}

		[Theory]
		[InlineData("a", 26, "a")]
		[InlineData("qzmt-zixmtkozy-ivhz", 343, "very encrypted name")]
		public void Decrypter_DecryptsCorrectly(string encrypted, long shifts, string expectedResult)
		{
			Decrypter.Decrypt(encrypted, shifts).Should().Be(expectedResult);
		}
	}
}