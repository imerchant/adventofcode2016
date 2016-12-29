using System;
using System.Text;
using System.Text.RegularExpressions;

namespace IM.AdventOfCode2016.Day9
{
	public static class TextCompression
	{
		private static readonly Regex MarkerRegex = new Regex(@"\((?'nextChars'\d+)x(?'repeat'\d+)\)", RegexOptions.Compiled);

		public static string Decompress(string input)
		{
			var decompressed = new StringBuilder();

			for (var k = 0; k < input.Length; ++k)
			{
				var c = input[k];

				if (char.IsWhiteSpace(c))
					continue;

				if (c == '(')
				{
					var close = input.IndexOf(')', k);
					var marker = input.Substring(k, close - k + 1);

					var match = MarkerRegex.Match(marker);
					if(!match.Success)
						throw new Exception($"could not parse marker \"{marker}\" at index {k}");

					var nextCount = int.Parse(match.Groups["nextChars"].Value);
					var repeat = int.Parse(match.Groups["repeat"].Value);

					var fragment = input.Substring(close + 1, nextCount);

					for (var i = 0; i < repeat; ++i)
						decompressed.Append(fragment);

					k = close + nextCount;
					continue;
				}

				decompressed.Append(c);
			}

			return decompressed.ToString();
		}

		public static long DecompressedLengthV2(string input)
		{
			var length = 0L;

			for (var k = 0; k < input.Length; ++k)
			{
				var c = input[k];

				if (char.IsWhiteSpace(c))
					continue;

				if (c == '(')
				{
					var close = input.IndexOf(')', k);
					var marker = input.Substring(k, close - k + 1);

					var match = MarkerRegex.Match(marker);
					if (!match.Success)
						throw new Exception($"could not parse marker \"{marker}\" at index {k}");

					var nextCount = int.Parse(match.Groups["nextChars"].Value);
					var repeat = int.Parse(match.Groups["repeat"].Value);

					var fragment = input.Substring(close + 1, nextCount);

					length += DecompressedLengthV2(fragment) * repeat;

					k = close + nextCount;

					continue;
				}

				length++;
			}

			return length;
		}
	}
}
