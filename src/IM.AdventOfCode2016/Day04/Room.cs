using System;

namespace IM.AdventOfCode2016.Day04
{
	public class Room
	{
		public long Id { get; }
		public string EncryptedName { get; }

		private readonly Lazy<string> _checksum;
		public string Checksum => _checksum.Value;

		private string _unencryptedName;
		public string Name => _unencryptedName ?? (_unencryptedName = Decrypter.Decrypt(EncryptedName, Id));

		public Room(long id, string encryptedName)
		{
			Id = id;
			EncryptedName = encryptedName;
			_checksum = new Lazy<string>(GenerateChecksum);
		}

		private string GenerateChecksum()
		{
			return EncryptedName.Checksum();
		}

		public override string ToString()
		{
			return $"{EncryptedName}-{Id}[{Checksum}]";
		}
	}
}
