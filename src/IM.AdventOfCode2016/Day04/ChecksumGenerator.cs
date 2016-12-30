using System.Collections.Generic;
using System.Linq;

namespace IM.AdventOfCode2016.Day04
{
	public static class ChecksumGenerator
	{
		public static string Checksum(this string source)
		{
			var letters = new Dictionary<char, Letter>(26);
			foreach (var c in source.Where(char.IsLetter))
			{
				var letter = letters.GetValueOrDefault(c, new Letter(c));
				letter.Count++;
				letters[c] = letter;
			}

			return letters.Values
				.OrderByDescending(x => x.Count)
				.ThenBy(x => x.Char)
				.Take(5)
				.Select(x => x.Char)
				.AsString();
		}
	}
}