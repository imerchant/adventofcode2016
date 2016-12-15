using System;

namespace IM.AdventOfCode2016.Day4
{
	public class Room
	{
		public long Id { get; }
		public string Name { get; }

		private readonly Lazy<string> _checksum;
		public string Checksum => _checksum.Value;

		public Room(long id, string name)
		{
			Id = id;
			Name = name;
			_checksum = new Lazy<string>(GenerateChecksum);
		}

		private string GenerateChecksum()
		{
			return Name.Checksum();
		}

		public override string ToString()
		{
			return $"{Name}-{Id}[{Checksum}]";
		}
	}
}
