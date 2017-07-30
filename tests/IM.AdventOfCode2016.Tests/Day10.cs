using FluentAssertions;
using IM.AdventOfCode2016.Day10;
using System;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day10 : TestBase
	{
		public Day10(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Puzzle1_FineDroneThatCompares61and17()
		{
			var ops = Inputs.Day10Parse(Inputs.Day10);
			var state = new BotState(61, 17);

			foreach(var op in ops.LoadBotOperations)
			{
				Output.WriteLine(state.LoadBot(op));
			}

			foreach(var op in ops.SwapOperations)
			{
				Output.WriteLine(state.Swap(op));
			}
		}

		[Fact]
		public void Puzzle1_ExampleSwapIsFound()
		{
			const string example = @"value 5 goes to bot 2
bot 2 gives low to bot 1 and high to bot 0
value 3 goes to bot 1
bot 1 gives low to output 1 and high to bot 0
bot 0 gives low to output 2 and high to output 0
value 2 goes to bot 2";

			var ops = Inputs.Day10Parse(example);
			ops.LoadBotOperations.Should().HaveCount(3);
			ops.SwapOperations.Should().HaveCount(3);

			var state = new BotState(5, 2);

			ops.LoadBotOperations.ForEach(op => state.LoadBot(op));

			Action swaps = () => ops.SwapOperations.ForEach(op => state.Swap(op));

			swaps.ShouldThrowExactly<Exception>().WithMessage("bot 2 was responsible for comparing 2 and 5");
		}

		[Fact]
		public void Puzzle1_StateCanCorrectlyIdentifySwapMatch()
		{
			var value1 = 2;
			var value2 = 4;
			var handOff = new HandOff(1, value1, value2);
			var lookingFor = new Tuple<int, int>(value1, value2);

			BotState.Matches(handOff, lookingFor).Should().BeTrue();
		}
	}
}
