using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using IM.AdventOfCode2016.Day1;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public static class Utilities
	{
		private static readonly Regex Day1MoveRegex = new Regex(@"\b(?'direction'[lrLR]{1})(?'distance'\d+)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

		public static IList<Move> Day1ParseMoves(string moves) =>
			(from match in Day1MoveRegex.Matches(moves).Cast<Match>()
			let direction = match.Groups["direction"].Value.ParseAsEnum<TurningDirection>()
			let distance = long.Parse(match.Groups["distance"].Value)
			select new Move(direction, distance)).ToList();
	}

	public class UtilitiesTest : TestBase
	{
		private readonly List<Move> R2L3;

		public UtilitiesTest(ITestOutputHelper output) : base(output)
		{
			R2L3 = new List<Move>
			{
				new Move(TurningDirection.R, 2),
				new Move(TurningDirection.L, 3)
			};
		}

		[Fact]
		public void Day1ParseMoves_CreatesCorrectMoveList()
		{
			const string moves = "R2, L3";

			var actual = Utilities.Day1ParseMoves(moves);

			actual.ShouldBeEquivalentTo(R2L3);
		}
	}
}
