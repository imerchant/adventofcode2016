using FluentAssertions;
using IM.AdventOfCode2016.Day6;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day6 : TestBase
	{
		public Day6(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Puzzle1_RecoverMessageByMostCommonLetter()
		{
			var messages = Inputs.Day6Parse(Inputs.Day6);

			var message = MessageRecovery.RecoverByMostCommon(messages);

			Output.WriteLine($"Recovered message: {message}");

			message.Should().Be("cyxeoccr");
		}

		private const string Puzzle1Example = @"eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar";

		[Fact]
		public void CanRecoverMessageFrom_Puzzle1Example()
		{
			var messages = Inputs.Day6Parse(Puzzle1Example);

			MessageRecovery.RecoverByMostCommon(messages).Should().Be("easter");
		}
	}
}