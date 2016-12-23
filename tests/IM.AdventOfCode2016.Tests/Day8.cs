using System;
using FluentAssertions;
using IM.AdventOfCode2016.Day8;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day8 : TestBase
	{
		public Day8(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Puzzle1_CountLitPixels()
		{
			var screen = new Screen();
			var instructions = Inputs.Day8Parse(Inputs.Day8);

			foreach (var operate in instructions)
				operate(screen);

			var litCount = screen.LitCount; // 110

			Output.WriteLine(screen.ToString());
			Output.WriteLine($"Lit pixels after {instructions.Count} operations: {litCount}");

			litCount.Should().Be(110);
		}

		[Fact]
		public void Sandbox()
		{
			var screen = new Screen();
			Print(screen);

			DoTo(screen, s => s.Rect(3, 2));

			//DoTo(screen, s => s.RotateRow(0, 3));

			DoTo(screen, s => s.RotateColumn(2, 2));

			screen.LitCount.Should().Be(6);
		}

		[Fact]
		public void Puzzle1_ExampleFlow()
		{
			var screen = new Screen(3, 7);

			DoTo(screen, s => s.Rect(3, 2));
			DoTo(screen, s => s.RotateColumn(1, 1));
			DoTo(screen, s => s.RotateRow(0, 4));
			DoTo(screen, s => s.RotateColumn(1, 1));
		}

		[Fact]
		public void Puzzle1_ExampleFlowFromRawInstructions()
		{
			const string rawInstructions = @"rect 3x2
rotate column x=1 by 1
rotate row y=0 by 4
rotate column x=1 by 1";

			var instructions = Inputs.Day8Parse(rawInstructions);
			var screen = new Screen(3, 7);

			foreach (var i in instructions)
			{
				DoTo(screen, i);
			}
		}

		private void DoTo(Screen screen, Action<Screen> action)
		{
			action(screen);
			Print(screen);
		}

		private void Print(Screen screen)
		{
			Output.WriteLine(screen.ToString());
			Output.WriteLine("     ");
		}
	}
}