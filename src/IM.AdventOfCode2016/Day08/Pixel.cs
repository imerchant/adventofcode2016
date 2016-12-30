namespace IM.AdventOfCode2016.Day08
{
	public struct Pixel
	{
		public bool Lit { get; private set; }
		public char Value => Lit ? '#' : '.';

		public void On() => Lit = true;
		public void Off() => Lit = false;

		public override string ToString()
		{
			return $"{Value}";
		}
	}
}