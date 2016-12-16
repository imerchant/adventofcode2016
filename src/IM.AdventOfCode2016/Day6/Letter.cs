namespace IM.AdventOfCode2016.Day6
{
	public struct Letter
	{
		public char Char { get; }
		public int Count { get; set; }

		public Letter(char c)
		{
			Char = c;
			Count = 0;
		}
	}
}