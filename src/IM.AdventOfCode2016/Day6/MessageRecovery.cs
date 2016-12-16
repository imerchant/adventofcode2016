using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace IM.AdventOfCode2016.Day6
{
	public static class MessageRecovery
	{
		public static string RecoverByMostCommon(List<string> messages)
		{
			var chars = messages[0].Length;

			var columns = Enumerable.Range(0, chars).Select(x => new Dictionary<char, Letter>(26)).ToArray();

			foreach (var message in messages)
			{
				for (var k = 0; k < chars; ++k)
				{
					var c = message[k];
					var letter = columns[k].GetValueOrDefault(c, new Letter(c));
					letter.Count++;
					columns[k][c] = letter;
				}
			}

			return columns.Select(col => col.Values.MaxBy(l => l.Count).Char).AsString();
		}
	}
}
