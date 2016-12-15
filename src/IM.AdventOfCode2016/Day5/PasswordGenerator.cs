using System.Security.Cryptography;
using System.Text;

namespace IM.AdventOfCode2016.Day5
{
	public static class PasswordGenerator
	{
		private const string InterestingStart = "00000";

		public static string GenerateInOrder(string input)
		{
			using (var hasher = MD5.Create())
			{
				var password = new StringBuilder(8);
				for (var k = 0; password.Length < 8; ++k)
				{
					var seed = $"{input}{k}";

					var md5 = GenerateHash(hasher, seed);

					if (!md5.StartsWith(InterestingStart))
						continue;

					password.Append(md5[5]);
				}
				return password.ToString();
			}
		}

		private static string GenerateHash(MD5 hasher, string input)
		{
			var data = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
			var hash = new StringBuilder(data.Length);
			foreach (var b in data)
			{
				hash.Append($"{b:x2}");
			}
			return hash.ToString();
		}
	}
}
