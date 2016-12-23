﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using IM.AdventOfCode2016.Day1;
using IM.AdventOfCode2016.Day2;
using IM.AdventOfCode2016.Day3;
using IM.AdventOfCode2016.Day4;

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

		private static readonly IDictionary<int, string> _inputs = new ConcurrentDictionary<int, string>();
		private static string GetDay(int day)
		{
			string input;
			if (_inputs.TryGetValue(day, out input))
				return input;

			input = File.ReadAllText($@"Input/Day{day}.txt");
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

		public static List<string> Day6Parse(string input) => input.SplitOn('\n').TrimEach().ToList();

		public static List<string> Day7Parse(string input) => input.SplitOn('\n').TrimEach().ToList();
	}
}
