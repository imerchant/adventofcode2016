using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit.Abstractions;

namespace IM.AdventOfCode2016.Tests
{
	public abstract class TestBase
	{
		protected ITestOutputHelper Output { get; }

		protected TestBase(ITestOutputHelper output)
		{
			Output = output;
		}
	}

	public static class TestExtensions
	{
		private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

		public static void WriteObject<T>(this ITestOutputHelper output, T value) where T : class
		{
			var json = JsonConvert.SerializeObject(value, Formatting.Indented, Settings);
		}
	}
}