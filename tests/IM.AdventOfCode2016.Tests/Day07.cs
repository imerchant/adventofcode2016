using System.Linq;
using FluentAssertions;
using IM.AdventOfCode2016.Day07;
using Xunit;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public class Day07 : TestBase
	{
		public Day07(ITestOutputHelper output) : base(output)
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

		[Fact]
		public void Puzzle2_CountSslAddresses()
		{
			var ips = Inputs.Day7Parse(Inputs.Day7);

			var count = ips.Count(IpAssessment.SupportsSsl); // 258

			Output.WriteLine($"Number of IPs that support SSL: {count}");

			count.Should().Be(258);
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

		[Theory]
		[InlineData("aba[bab]xyz", true)]
		[InlineData("xyx[xyx]xyx", false)]
		[InlineData("aaa[kek]eke", true)]
		[InlineData("zazbz[bzb]cdb", true)]
		public void Puzzle2_TestCasesPass(string ip, bool expected)
		{
			IpAssessment.SupportsSsl(ip).Should().Be(expected);
		}

		[Theory]
		[InlineData("aba", "bab")]
		[InlineData("kek", "eke")]
		public void AbaToBab_WorksCorrectly(string fragment, string expected)
		{
			fragment.AbaToBab().Should().Be(expected);
		}
	}
}