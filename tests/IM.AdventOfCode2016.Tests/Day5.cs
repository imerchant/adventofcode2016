using System.Diagnostics;
using FluentAssertions;
using IM.AdventOfCode2016.Day5;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day5 : TestBase
	{
		public Day5(ITestOutputHelper output) : base(output)
		{
		}

		[Fact(Skip = "this takes >3 minutes")]
		public void Puzzle1_GeneratePassword()
		{
			var watch = Stopwatch.StartNew();
			var password = PasswordGenerator.GenerateInOrder(Inputs.Day5); // 1a3099aa
			watch.Stop();

			Output.WriteLine($"Password: {password}");
			Output.WriteLine($"Time elapsed: {watch.Elapsed}");
		}

		[Fact(Skip = "holy balls this takes forever")]
		public void Puzzle1_GivenTestCaseWorks()
		{
			const string input = "abc";

			var watch = Stopwatch.StartNew();
			var password = PasswordGenerator.GenerateInOrder(input);
			watch.Stop();

			Output.WriteLine($"Password: {password}");
			Output.WriteLine($"Time elapsed: {watch.Elapsed}");
			password.Should().Be("18f47a30");
		}
	}
}