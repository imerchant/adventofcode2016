using System;
using System.Collections.Generic;

namespace IM.AdventOfCode2016.Day10
{
	public class BotState
	{
		public Dictionary<int, Bot> Bots { get; }
		public Dictionary<int, Output> Outputs { get; }
		public Tuple<int, int> LookingFor { get; }

		public BotState(int one, int two)
		{
			Bots = new Dictionary<int, Bot>();
			Outputs = new Dictionary<int, Output>();
			LookingFor = new Tuple<int, int>(one, two);
		}

		public Bot GetBot(int id)
		{
			if (!Bots.ContainsKey(id))
				Bots[id] = new Bot(id);
			return Bots[id];
		}

		public Output GetOutput(int id)
		{
			if (!Outputs.ContainsKey(id))
				Outputs[id] = new Output(id);
			return Outputs[id];
		}

		public IReceiver GetTarget(Target target)
		{
			switch (target.Type)
			{
				case TargetType.Bot:
					return GetBot(target.Id);
				case TargetType.Output:
					return GetOutput(target.Id);
				default:
					throw new Exception($"invalid TargetType: {target.Type}");
			}
		}

		public string LoadBot(LoadBotOperation operation)
		{
			GetBot(operation.BotId).Take(operation.Value);
			return operation.ToString();
		}

		public string Swap(SwapOperation operation)
		{
			var sourceBot = GetBot(operation.SourceBot);
			var low = GetTarget(operation.Low);
			var high = GetTarget(operation.High);

			if (!sourceBot.CanHandOff)
				return $"could not handoff because sourcebot {sourceBot} said it couldn't; op: {operation}";

			var handOff = sourceBot.HandOff();
			if (Matches(handOff, LookingFor))
				throw new Exception($"bot {handOff.BotId} was responsible for comparing {handOff.Low} and {handOff.High}");

			low.Take(handOff.Low);
			high.Take(handOff.High);

			return $"performed swap {operation} with handoff {handOff}";
		}

		public static bool Matches(HandOff handOff, Tuple<int, int> lookingFor)
		{
			return (handOff.Low == lookingFor.Item1 || handOff.Low == lookingFor.Item2)
				&& (handOff.High == lookingFor.Item1 || handOff.High == lookingFor.Item2);
		}
	}
}
