using System;

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
	}
}
