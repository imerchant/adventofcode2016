using System.Collections.Generic;

namespace IM.AdventOfCode2016.Day10
{

	public class BotOps
	{
		public List<LoadBotOperation> LoadBotOperations { get; }
		public List<SwapOperation> SwapOperations { get; }

		public BotOps()
		{
			LoadBotOperations = new List<LoadBotOperation>();
			SwapOperations = new List<SwapOperation>();
		}
	}

	public struct LoadBotOperation
	{
		public int BotId { get; }
		public int Value { get; }

		public LoadBotOperation(int botId, int value)
		{
			BotId = botId;
			Value = value;
		}

		public override string ToString()
		{
			return $"load bot {BotId} with value {Value}";
		}
	}

	public enum TargetType : sbyte
	{
		Bot,
		Output
	}

	public struct Target
	{
		public int Id { get; }
		public TargetType Type { get; }

		public Target(int id, TargetType type)
		{
			Id = id;
			Type = type;
		}

		public override string ToString()
		{
			return $"{Type:G} {Id}";
		}
	}

	public struct SwapOperation
	{
		public int SourceBot { get; }
		public Target Low { get; }
		public Target High { get; }

		public SwapOperation(int sourceBot, Target low, Target high)
		{
			SourceBot = sourceBot;
			Low = low;
			High = high;
		}

		public override string ToString()
		{
			return $"source {SourceBot}; low {Low}; high {High}";
		}
	}
}
