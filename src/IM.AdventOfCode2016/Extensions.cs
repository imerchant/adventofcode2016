using System;
using System.Collections.Generic;
using System.Linq;

namespace IM.AdventOfCode2016
{
	public static class Extensions
	{
		public static TEnum ParseAsEnum<TEnum>(this string source, bool ignoreCase = true) where TEnum : struct, IConvertible
		{
			if (typeof(TEnum).IsEnum == false)
				throw new ArgumentException("given Type is not an enum");
			return (TEnum)Enum.Parse(typeof(TEnum), source, ignoreCase);
		}

		public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
		{
			TValue value;
			return dict != null && dict.TryGetValue(key, out value) ? value : defaultValue;
		}

		public static bool HasAny<T>(this IEnumerable<T> source)
		{
			return source != null && source.Any();
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			var count = 0;
			foreach (var item in source)
				action(item, count++);
		}

		public static string[] SplitOn(this string source, params char[] separators)
		{
			return source?.Split(separators, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
		}

		public static IEnumerable<string> TrimEach(this IEnumerable<string> source)
		{
			return source?.Select(x => x.Trim()) ?? Enumerable.Empty<string>();
		}

		public static string AsString(this IEnumerable<char> chars)
		{
			return new string(chars.ToArray());
		}

		public static List<string> SplitLines(this string source)
		{
			return source.SplitOn('\n').TrimEach().ToList();
		}

		public static int? ToInt(this string source)
		{
			return int.TryParse(source, out int i) ? i : (int?)null;
		}
	}
}
