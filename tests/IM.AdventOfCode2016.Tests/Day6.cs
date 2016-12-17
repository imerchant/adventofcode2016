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

			var message = MessageRecovery.RecoverByMostCommon(messages); // "cyxeoccr"

			Output.WriteLine($"Recovered message: {message}");

			message.Should().Be("cyxeoccr");
		}

		[Fact]
		public void Puzzle2_RecoverMessageByLeastCommonLetter()
		{
			var messages = Inputs.Day6Parse(Inputs.Day6);

			var message = MessageRecovery.RecoverByLeastCommon(messages); // "batwpask"

			Output.WriteLine($"Recovered message: {message}");

			message.Should().Be("batwpask");
		}

		private const string PuzzleExample = @"eedadn
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
		public void CanRecoverMessageFrom_ByMostCommon()
		{
			var messages = Inputs.Day6Parse(PuzzleExample);

			MessageRecovery.RecoverByMostCommon(messages).Should().Be("easter");
		}

		[Fact]
		public void CanRecoverMessage_ByLeastCommon()
		{
			var messages = Inputs.Day6Parse(PuzzleExample);

			MessageRecovery.RecoverByLeastCommon(messages).Should().Be("advent");
		}
	}
}