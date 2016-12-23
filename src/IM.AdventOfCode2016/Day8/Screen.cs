using System.Linq;
using System.Text;

namespace IM.AdventOfCode2016.Day8
{
	public class Screen
	{
		private readonly Pixel[][] _pixels;

		public int LitCount => _pixels.Sum(line => line.Count(p => p.Lit));

		public Screen() : this(6, 50)
		{
		}

		public Screen(int rows, int columns)
		{
			_pixels = new Pixel[rows][];
			for (var k = 0; k < _pixels.Length; ++k)
			{
				_pixels[k] = new Pixel[columns];
			}
		}

		public void Rect(int cols, int rows)
		{
			for (var row = 0; row < rows; ++row)
				for (var col = 0; col < cols; ++col)
					_pixels[row][col].On();
		}

		public void RotateRow(int row, int count)
		{
			var thisRow = _pixels[row];
			for (var k = 0; k < count; ++k)
			{
				var last = thisRow[thisRow.Length - 1];
				for (var col = thisRow.Length - 1; col > 0; --col)
				{
					thisRow[col] = thisRow[col - 1];
				}
				thisRow[0] = last;
			}
		}

		public void RotateColumn(int col, int count)
		{
			for (var k = 0; k < count; ++k)
			{
				var last = _pixels[_pixels.Length - 1][col];
				for (var row = _pixels.Length - 1; row > 0; --row)
				{
					_pixels[row][col] = _pixels[row - 1][col];
				}
				_pixels[0][col] = last;
			}
		}

		public override string ToString()
		{
			var builder = new StringBuilder();
			foreach (var line in _pixels)
			{
				builder.AppendLine(line.AsString());
			}
			return builder.ToString();
		}
	}
}
