using System.Security.Cryptography;
using System.Text;

namespace IM.AdventOfCode2016.Day05
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

		public static string GenerateOutOfOrder(string input)
		{
			using (var hasher = MD5.Create())
			{
				var password = new string('_', 8).ToCharArray();
				var found = 0;
				for (var k = 0; found < 8; ++k)
				{
					var seed = $"{input}{k}";

					var md5 = GenerateHash(hasher, seed);

					if (!md5.StartsWith(InterestingStart))
						continue;

					var maybePosition = md5[5];

					int position;
					if (!int.TryParse($"{maybePosition}", out position) || position > 7 || password[position] != '_')
						continue;

					password[position] = md5[6];
					found++;
				}
				return password.AsString();
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
