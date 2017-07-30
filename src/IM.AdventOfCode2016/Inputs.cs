using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using IM.AdventOfCode2016.Day01;
using IM.AdventOfCode2016.Day02;
using IM.AdventOfCode2016.Day03;
using IM.AdventOfCode2016.Day04;
using IM.AdventOfCode2016.Day08;
using IM.AdventOfCode2016.Day10;

namespace IM.AdventOfCode2016
{
	public static class Inputs
	{
		public const string Day1 = @"R2, L3, R2, R4, L2, L1, R2, R4, R1, L4, L5, R5, R5, R2, R2, R1, L2, L3, L2, L1, R3, L5, R187, R1, R4, L1, R5, L3, L4, R50, L4, R2, R70, L3, L2, R4, R3, R194, L3, L4, L4, L3, L4, R4, R5, L1, L5, L4, R1, L2, R4, L5, L3, R4, L5, L5, R5, R3, R5, L2, L4, R4, L1, R3, R1, L1, L2, R2, R2, L3, R3, R2, R5, R2, R5, L3, R2, L5, R1, R2, R2, L4, L5, L1, L4, R4, R3, R1, R2, L1, L2, R4, R5, L2, R3, L4, L5, L5, L4, R4, L2, R1, R1, L2, L3, L2, R2, L4, R3, R2, L1, L3, L2, L4, L4, R2, L3, L3, R2, L4, L3, R4, R3, L2, L1, L4, R4, R2, L4, L4, L5, L1, R2, L5, L2, L3, R2, L2";

		public const string Day2 =
@"UULDRRRDDLRLURUUURUURDRUURRDRRURUDRURRDLLDRRRDLRUDULLRDURLULRUUURLDDRURUDRULRDDDUDRDLDDRDDRUURURRDDRLRLUDLUURURLULLLRRDRLDRLRDLULULRDRDDUURUDRRURDLRRDDDLUULDURDLDLLRLRLLUDUDLRDDLUURUUDDRDULDDLDLLDULULRLDDDUDDDRLLRURLRDUUUDUUDDURRDLDDLRDLLUDDLDRLDULDRURLUUDLURLUDRULRLRUUUURLUUUDDULLRLLURDRURLLRLRLDDRURURULRULLUUUULUDULDDDRDDLURLUURRLDDRDRUDDRRLURRDURRLDUULRRLLRDLLDDUURULLRUURRRRDRRURLULLRLRDDULULRDLDDLULLD
UUDUDDRRURRUDDRLDLURURLRLLDRLULLUURLLURDRLLURLLRRLURDLDURUDRURURDLRDRRDULRLLLRDLULDRLLDLDRLDDRUUUUULRLDUURDUUUURUUDLRDLLDRLURULDURURLDLLRDLULLULLLLLUDUDDLRLLLUDLRUUDDUUDUDDDLULDDUDUULUUDUDRRULRRRURUDUUULDDRURLLULLULURLUDRDLUUUDLDRRLRRRULLRRURRUDDDRDLDDDLDUDLLDRRDURRURRURRLDLURUULRLDLUDUDUUULULUUDDDLDDULRDULLULDRDDURRURRRULRDURULUDURRDLLUURRUURLLLULDRRULUUUURLRLRDDDDULLUUUDRRLRRLRRLLLUDDDLRDDURURRDULLLUDLUDURRLRDURUURURDRDUUURURRUDRURRULLDDURRLRRRUULDRLDRRURUDLULRLLRRDLDDRLRRULDDLLUURUDDUDRLUD
DDDUDDRRDRRRUULDRULDLDLURRRUURULRUDDRLLLLURRLRULDLURRULDRUDRRLLLLDULRDLUUURDDLDLURRLLUUURLLUDLUDRRDDULLULURDULRRDLRLDRRUUUUDLRRDLDDLDULDRUULRLLDLRURRUDLDDDRUUULLDDLULDULDUURUDDDLULUDLUURLRURUURDDUDRRLDRRRDDDDRDLUDRRDURDLDRURDDDRRLLLRDDRRRDDLDRLLUURRLDRDDRDLRDDLLDRLRDRDDDURLULLRUURDLULRURRUUDLDRLDRRDDRLDDUULLRDDRRLLLDDDUURDUDRUDUDULDULRUURLDURRDLUURRDLLDDLLURUUUDRLUURRDLUDUULRURLUDDLLRUDURRDRRRDRDLULRRLRUDULUUDRLURRRRLULURRDLLDRDDRLULURDURRDUUULLRDUUDLDUDURUDRUDDLRLULRLRLRRRLRUULLDDLUDDLDRRRLDDLLRLRLRUDULRLLLUULLDRDLDRRDULLRRLLDLDUDULUDDUUDLRDRLUUULLRLDLDDLLRUDDRDD
DDUURRLULDLULULLDUDDRURDDRLRDULUURURRLURDLRRDUUDLULDRDLDLRLULLRULLDRLDRRULUDRLDURUURLLDLLDDLUULLRLRULRLUURDDDDDRLDRLLLDLULDLDLULRRURLLLLLLRLUDLRRLRULUULLLLURDLLRLLDDUDLLULDLLURUUDLRDRDUDDDRDDUULRLLDDDLLRLURLUDLULRRUUUULLDLDLLLDRLUDRDRDLUDLRUDRDRUDRDLLDDLRRLRDLDURDLDRUUUDRLULUULDURDLUUUDDDDDLDRDURDLULDDLLUDUURRUDDLURUDDLRLUUDURUDUULULUDLDLUURDULURURULDDDLUUUUDLUUDUDLLLRDDLRDDLRURRRLLLULLURULLRDLLDRULRDDULULRLUDRRRDULRLLUDUULLRDRDDDULULRURULDLDLDRDLDUDRDULLUUUUUDLRDURDUUULLLRUULLRUULDRRUUDLLLULLUURLDDLUULLRLRLRDRLLLRLURDDURUDUULULDLRLRLLUDURRURDRUDLRDLLRDDRDUULRDRLLRULLUDDRLDLDDDDUDRDD
URDLUDUDLULURUDRLUDLUDLRLRLLDDDDDLURURUURLRDUDLRRUUDUURDURUULDRRRDDDLDUURRRDLRULRRDLRUDUDLDDDLLLRLRLRUUUUUULURRRLRLUDULURLDLLDUUDDRUDLDUDRRLULLULLDURDDRRLLRLDLLLLRLULLDDDDLDULLRDUURDUDURRUULLDRULUDLUULUUDDLDDRDLULLULDLDRLDLRULLRLURDURUDRLDURDRULRLLLLURRURLRURUDUDRRUDUUDURDDRRDRLURLURRLDRRLLRLRUDLRLLRLDLDDRDLURLLDURUDDUUDRRLRUDLUDULDRUDDRDRDRURDLRLLRULDDURLUUUUDLUDRRURDDUUURRLRRDDLULLLDLRULRRRLDRRURRURRUUDDDLDRRURLRRRRDLDLDUDURRDDLLLUULDDLRLURLRRURDRUULDDDUDRDRUDRRLRLLLLLURDULDUDRLULDRLUULUDDDDUDDRDDLDDRLLRULRRURDDDRDDLDLULRDDRRURRUDRDDDDRURDRRURUUDUDDUURULLDRDULURUDUD";

		public static string Day3 => GetDay(3);

		public static string Day4 => GetDay(4);

		public const string Day5 = "uqwqemis";

		public static string Day6 => GetDay(6);

		public static string Day7 => GetDay(7);

		public static string Day8 => GetDay(8);

		public static string Day9 => GetDay(9);

		public static string Day10 => GetDay(10);

		private static readonly IDictionary<int, string> _inputs = new ConcurrentDictionary<int, string>();
		private static string GetDay(int day)
		{
			string input;
			if (_inputs.TryGetValue(day, out input))
				return input;

			input = File.ReadAllText($@"Input/Day{day:00}.txt");
			_inputs[day] = input;

			return input;
		}

		private static readonly Regex Day1MoveRegex = new Regex(@"\b(?'direction'[lrLR]{1})(?'distance'\d+)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
		public static IList<Move> Day1Parse(string moves) =>
			(from match in Day1MoveRegex.Matches(moves).Cast<Match>()
			 let direction = match.Groups["direction"].Value.ParseAsEnum<TurningDirection>()
			 let distance = long.Parse(match.Groups["distance"].Value)
			 select new Move(direction, distance)).ToList();

		private static readonly IDictionary<char, Direction> DirectionMap = new ReadOnlyDictionary<char, Direction>(new Dictionary<char, Direction>
		{
			{ 'U', Direction.U },
			{ 'R', Direction.R },
			{ 'D', Direction.D },
			{ 'L', Direction.L }
		});
		public static Direction[][] Day2Parse(string moves)
		{
			var lines = moves.SplitOn('\n').TrimEach().ToArray();

			var directions = new Direction[lines.Length][];

			for (var k = 0; k < directions.Length; ++k)
			{
				directions[k] = lines[k].ToCharArray().Select(c => DirectionMap[c]).ToArray();
			}

			return directions;
		}

		public static List<Triangle> Day3ParseByRow(string input)
		{
			return input.SplitOn('\n')
				.TrimEach()
				.Select(line =>
				{
					var nums = line.SplitOn(' ').Select(x => long.Parse(x.Trim())).ToArray();
					return new Triangle(nums);
				}).ToList();
		}

		public static List<Triangle> Day3ParseByColumn(string input)
		{
			var lines = input.SplitOn('\n').TrimEach().ToList();

			var cols = new[] { new List<long>(), new List<long>(), new List<long>() };

			foreach (var line in lines)
			{
				line.SplitOn(' ').ForEach((item, index) => cols[index].Add(long.Parse(item)));
			}

			return cols.SelectMany(Day3TrianglesByThrees).ToList();
		}

		private static IEnumerable<Triangle> Day3TrianglesByThrees(List<long> numbers)
		{
			for (var k = 0; k < numbers.Count; k += 3)
			{
				yield return new Triangle(numbers[k], numbers[k+1], numbers[k+2]);
			}
		}

		public static readonly Regex Day4Regex = new Regex(@"^(?'name'[a-z\-]+?)-(?'id'\d+?)\[(?'checksum'\w+?)\]\r?$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
		public static List<RoomAndMaybeChecksum> Day4Parse(string input) =>
			Day4Regex.Matches(input)
				.Cast<Match>()
				.Select(line => new RoomAndMaybeChecksum
				(
					id: long.Parse(line.Groups["id"].Value),
					name: line.Groups["name"].Value,
					maybeChecksum: line.Groups["checksum"].Value
				))
				.ToList();

		public static List<string> Day6Parse(string input) => input.SplitLines();

		public static List<string> Day7Parse(string input) => input.SplitLines();

		private static readonly Regex Day8Rect = new Regex(@"^rect (?'cols'\d+)x(?'row'\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private static readonly Regex Day8RotateRow = new Regex(@"^rotate row y=(?'row'\d+) by (?'count'\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private static readonly Regex Day8RotateColumn = new Regex(@"^rotate column x=(?'col'\d+) by (?'count'\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public static List<Action<Screen>> Day8Parse(string input)
		{
			var lines = input.SplitLines();
			var moves = new List<Action<Screen>>();

			foreach (var line in lines)
			{
				var rectMatch = Day8Rect.Match(line);
				if (rectMatch.Success)
				{
					var cols = int.Parse(rectMatch.Groups["cols"].Value);
					var row = int.Parse(rectMatch.Groups["row"].Value);
					moves.Add(s => s.Rect(cols, row));
					continue;
				}

				var rotateRowMatch = Day8RotateRow.Match(line);
				if (rotateRowMatch.Success)
				{
					var row = int.Parse(rotateRowMatch.Groups["row"].Value);
					var count = int.Parse(rotateRowMatch.Groups["count"].Value);
					moves.Add(s => s.RotateRow(row, count));
					continue;
				}

				var rotateColMatch = Day8RotateColumn.Match(line);
				if (rotateColMatch.Success)
				{
					var col = int.Parse(rotateColMatch.Groups["col"].Value);
					var count = int.Parse(rotateColMatch.Groups["count"].Value);
					moves.Add(s => s.RotateColumn(col, count));
					continue;
				}

				throw new Exception($"cannot parse \"{line}\"");
			}

			return moves;
		}

		private static readonly Regex Initialization = new Regex(@"value (?'value'\d+?) goes to bot (?'bot'\d+?)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private static readonly Regex SwapOperation = new Regex(@"bot (?'sourceBot'\d+?) gives low to (?'lowTargetType'bot|output) (?'lowTargetId'\d+?) and high to (?'highTargetType'bot|output) (?'highTargetId'\d+?)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public static BotOps Day10Parse(string input)
		{
			var lines = input.SplitLines();
			var ops = new BotOps();

			foreach(var line in lines)
			{
				var initializationMatch = Initialization.Match(line);
				if(initializationMatch.Success)
				{
					var bot = initializationMatch.Groups["bot"].Value.ToInt();
					var value = initializationMatch.Groups["value"].Value.ToInt();

					if (!bot.HasValue || !value.HasValue)
						throw new Exception($"could not parse \"{line}\" because value or bot could not be parsed");

					ops.LoadBotOperations.Add(new LoadBotOperation(bot.Value, value.Value));

					continue;
				}

				var swapMatch = SwapOperation.Match(line);
				if(swapMatch.Success)
				{
					var sourceBot = swapMatch.Groups["sourceBot"].Value.ToInt();
					var lowTargetType = swapMatch.Groups["lowTargetType"].Value.ParseAsEnum<TargetType>();
					var lowTargetId = swapMatch.Groups["lowTargetId"].Value.ToInt();
					var highTargetType = swapMatch.Groups["highTargetType"].Value.ParseAsEnum<TargetType>();
					var highTargetId = swapMatch.Groups["highTargetId"].Value.ToInt();

					if (!sourceBot.HasValue || !lowTargetId.HasValue || !highTargetId.HasValue)
						throw new Exception($"could not parse \"{line}\" because source, low, or high id could not be parsed");

					ops.SwapOperations.Add(new SwapOperation(sourceBot.Value, new Target(lowTargetId.Value, lowTargetType), new Target(highTargetId.Value, highTargetType)));

					continue;
				}

				throw new Exception($"line {line} could not be parsed");
			}

			return ops;
		}
	}
}