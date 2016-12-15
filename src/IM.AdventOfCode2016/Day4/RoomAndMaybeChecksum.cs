namespace IM.AdventOfCode2016.Day4
{
	public struct RoomAndMaybeChecksum
	{
		public Room Room { get; }
		public string MaybeChecksum { get; }

		public long Value => Room.Checksum == MaybeChecksum ? Room.Id : 0L;

		public RoomAndMaybeChecksum(long id, string name, string maybeChecksum)
		{
			Room = new Room(id, name);
			MaybeChecksum = maybeChecksum;
		}
	}
}