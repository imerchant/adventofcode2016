namespace IM.AdventOfCode2016.Day01
{
	public struct Move
	{
		public TurningDirection Direction { get; private set; }
		public long Distance { get; private set; }

		public Move(TurningDirection direction, long distance)
		{
			Direction = direction;
			Distance = distance;
		}
	}
}