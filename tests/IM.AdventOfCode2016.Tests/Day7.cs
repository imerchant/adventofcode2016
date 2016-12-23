using System.Linq;
using FluentAssertions;
using IM.AdventOfCode2016.Day7;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day7 : TestBase
	{
		public Day7(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Puzzle1_CountTLSAddresses()
		{
			var ips = Inputs.Day7Parse(Inputs.Day7);

			var count = ips.Count(IpAssessment.SupportsTls); // 105

			Output.WriteLine($"Number of IPs that support TLS: {count}");

			count.Should().Be(105);
		}

		[Theory]
		[InlineData("abba[mnop]qrst", true)]
		[InlineData("abcd[bddb]xyyx", false)] // match within brackets
		[InlineData("aaaa[qwer]tyui", false)] // match cannot be all the same char
		[InlineData("ioxxoj[asdfgh]zxcvbn", true)]
		[InlineData("vjqhodfzrrqjshbhx[lezezbbswydnjnz]ejcflwytgzvyigz[hjdilpgdyzfkloa]mxtkrysovvotkuyekba", true)]
		public void Puzzle1_TestCasesPass(string ip, bool expectedSupportsTls)
		{
			IpAssessment.SupportsTls(ip).Should().Be(expectedSupportsTls);
		}

		[Theory]
		[InlineData("aaaa", false)]
		[InlineData("abba", true)]
		[InlineData("abbc", false)]
		public void CanIdentifyAbba(string fragment, bool expected)
		{
			IpAssessment.IsAbba(fragment).Should().Be(expected);
		}
	}
}