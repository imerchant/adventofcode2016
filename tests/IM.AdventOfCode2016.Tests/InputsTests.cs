using System.Collections.Generic;
using FluentAssertions;
using IM.AdventOfCode2016.Day1;
using IM.AdventOfCode2016.Day2;
using IM.AdventOfCode2016.Day4;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class InputsTests : TestBase
	{
		private readonly List<Move> R2L3;
		private readonly Direction[][] _day2ExampleExpected;
		private readonly List<RoomAndMaybeChecksum> _day4ExampleExpected;

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

			_day4ExampleExpected = new List<RoomAndMaybeChecksum>
			{
				new RoomAndMaybeChecksum(123, "aaaaa-bbb-z-y-x", "abxyz"),
				new RoomAndMaybeChecksum(987, "a-b-c-d-e-f-g-h", "abcde"),
				new RoomAndMaybeChecksum(404, "not-a-real-room", "oarel"),
				new RoomAndMaybeChecksum(200, "totally-real-room", "decoy")
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

		[Fact]
		public void Day4Parse_CreatesCorrectRoomAndMaybeChecksumList()
		{
			const string exampleInput = @"aaaaa-bbb-z-y-x-123[abxyz]
a-b-c-d-e-f-g-h-987[abcde]
not-a-real-room-404[oarel]
totally-real-room-200[decoy]";

			var actual = Inputs.Day4Parse(exampleInput);

			actual.ShouldBeEquivalentTo(_day4ExampleExpected);
		}

		[Fact]
		public void Day4Regex_Works()
		{
			const string input = "aaaaa-bbb-z-y-x-123[abxyz]";

			Inputs.Day4Regex.IsMatch(input).Should().BeTrue();
		}

		[Fact]
		public void Day4Parse_IngestsCorrectNumberOfRooms()
		{
			var rooms = Inputs.Day4Parse(Inputs.Day4);

			rooms.Should().HaveCount(1091);
		}

		[Fact]
		public void Day6Parse_IngestsCorrectNumberOfStrings()
		{
			var messages = Inputs.Day6Parse(Inputs.Day6);

			messages.Should().HaveCount(650);
		}

		[Fact]
		public void Day7Parse_IngestsCorrectNumberOfStrings()
		{
			var messages = Inputs.Day7Parse(Inputs.Day7);

			messages.Should().HaveCount(2000);
		}
	}
}
