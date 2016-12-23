using System;
using System.Diagnostics;

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

		public static bool IsAbba(this string fragment)
		{
			if (fragment.Length != 4)
				return false;

			return fragment[0] != fragment[1] && fragment[0] == fragment[3] && fragment[1] == fragment[2];
		}
	}
}
