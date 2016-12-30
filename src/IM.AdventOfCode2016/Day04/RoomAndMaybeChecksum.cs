namespace IM.AdventOfCode2016.Day04
{
	public struct RoomAndMaybeChecksum
	{
		public Room Room { get; }
		public string MaybeChecksum { get; }

		public long Value => IsReal ? Room.Id : 0L;

		public bool IsReal => Room.Checksum == MaybeChecksum;

		public RoomAndMaybeChecksum(long id, string name, string maybeChecksum)
		{
			Room = new Room(id, name);
			MaybeChecksum = maybeChecksum;
		}
	}
}