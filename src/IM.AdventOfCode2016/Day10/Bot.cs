using System;
using System.Collections.Generic;

namespace IM.AdventOfCode2016.Day10
{
	public interface IReceiver
	{
		void Take(int i);
	}

	public class Bot : IReceiver
	{
		public int Id { get; }
		public List<int> Chips { get; }

		public bool CanHandOff => Chips.Count >= 2;

		public Bot(int id)
		{
			Id = id;
			Chips = new List<int>(3);
		}

		public void Take(int i)
		{
			if (Chips.Count > 2)
				throw new Exception($"Bot {Id} cannot take value {i} because it already has {Chips[0]} and {Chips[1]}");

			Chips.Add(i);
		}

		public HandOff HandOff()
		{
			if (Chips.Count < 1)
				throw new Exception($"Bot {Id} cannot hand off because it has no values");

			if (Chips.Count < 2)
				throw new Exception($"Bot {Id} cannot hand off as it only has 1 value ({Chips[0]})");

			var first = Chips[0];
			var second = Chips[1];
			Chips.Clear();

			return new HandOff(Id, Math.Min(first, second), Math.Max(first, second));
		}

		public override string ToString()
		{
			return $"-bot {Id} ({string.Join(",", Chips)})-";
		}
	}

	public struct HandOff
	{
		public int BotId { get; }
		public int Low { get; }
		public int High { get; }

		public HandOff(int botId, int low, int high)
		{
			BotId = botId;
			Low = low;
			High = high;
		}

		public override string ToString()
		{
			return $"({BotId}: {Low}, {High})";
		}
	}

	public class Output : IReceiver
	{
		public int Id { get; }
		public int? Value;

		public Output(int id)
		{
			Id = id;
		}

		public void Take(int value)
		{
			if (Value.HasValue)
				throw new Exception($"output {Id} cannot take value {value} because it already has value {Value}");

			Value = value;
		}

		public override string ToString()
		{
			return $"-output {Id} ({Value})-";
		}
	}
}
