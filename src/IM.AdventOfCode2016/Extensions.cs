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
	}
}
