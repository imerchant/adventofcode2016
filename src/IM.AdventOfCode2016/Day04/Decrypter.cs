using System.Text;

namespace IM.AdventOfCode2016.Day04
{
	public static class Decrypter
	{
		private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

		public static string Decrypt(string encrypted, long shift)
		{
			var decrypted = new StringBuilder(encrypted.Length);

			foreach (var c in encrypted)
			{
				if (c == '-' || !char.IsLetter(c))
				{
					decrypted.Append(' ');
					continue;
				}
				var index = Alphabet.IndexOf(c);
				var next = (int)(index + shift % 26) % 26;
				decrypted.Append(Alphabet[next]);
			}

			return decrypted.ToString();
		}
	}
}