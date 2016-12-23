using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IM.AdventOfCode2016.Day7
{
	public static class IpAssessment
	{
		public static bool SupportsTls(string ip)
		{
			var supportsTls = false;
			var bracketCount = 0;
			for (var k = 0; k < ip.Length; ++k)
			{
				Debug.Write($"{k}\t");
				if (k + 4 > ip.Length)
					break;

				var slice = ip.Substring(k, 4);
				Debug.WriteLine($"{slice}");
				var openIndex = slice.IndexOf("[", StringComparison.CurrentCulture);
				var closeIndex = slice.IndexOf("]", StringComparison.CurrentCulture);
				if (openIndex >= 0)
				{
					++bracketCount;
					k = k + openIndex;
					continue;
				}
				if (closeIndex >= 0)
				{
					--bracketCount;
					k = k + closeIndex;
					continue;
				}

				var isAbba = slice.IsAbba();
				if (isAbba)
				{
					if (bracketCount > 0) return false;
					supportsTls = true;
				}
			}

			return bracketCount == 0 && supportsTls;
		}

		public static bool SupportsSsl(string ip)
		{
			var abas = new List<string>();
			var babs = new List<string>();
			var bracketCount = 0;

			for (var k = 0; k < ip.Length; ++k)
			{
				if (k + 3 > ip.Length)
					break;

				var slice = ip.Substring(k, 3);
				var openIndex = slice.IndexOf("[", StringComparison.CurrentCulture);
				var closeIndex = slice.IndexOf("]", StringComparison.CurrentCulture);
				if (openIndex >= 0)
				{
					++bracketCount;
					k = k + openIndex;
					continue;
				}
				if (closeIndex >= 0)
				{
					--bracketCount;
					k = k + closeIndex;
					continue;
				}

				if (slice.IsAba())
				{
					var collection = bracketCount > 0 ? babs : abas;
					collection.Add(slice);
				}
			}

			return abas.Any(aba => babs.Contains(aba.AbaToBab()));
		}

		internal static bool IsAbba(this string fragment)
		{
			if (fragment.Length != 4)
				return false;

			return fragment[0] != fragment[1] && fragment[0] == fragment[3] && fragment[1] == fragment[2];
		}

		private static bool IsAba(this string fragment)
		{
			if (fragment.Length != 3)
				return false;

			return fragment[0] != fragment[1] && fragment[0] == fragment[2];
		}

		internal static string AbaToBab(this string fragment)
		{
			if(!fragment.IsAba()) throw new Exception($"\"{fragment}\" isn't an aba");

			return $"{fragment[1]}{fragment[0]}{fragment[1]}";
		}
	}
}
