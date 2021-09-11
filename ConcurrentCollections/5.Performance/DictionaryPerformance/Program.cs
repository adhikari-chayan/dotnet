using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Pluralsight.ConcurrentCollections.DictionaryPerformance
{
	class Program
	{
		static void Main(string[] args)
		{
			int dictSize = 200000;

			Console.WriteLine("Dictionary, single thread:");
			var dict = new Dictionary<int, int>();
			SingleThreadBenchmark.Benchmark(dict, dictSize);

			Console.WriteLine("\r\nConcurrentDictionary, single thread:");
			var dict2 = new ConcurrentDictionary<int, int>();
			SingleThreadBenchmark.Benchmark(dict2, dictSize);

			Console.WriteLine("\r\nConcurrentDictionary, multiple threads:");
			var dict3 = new ConcurrentDictionary<int, int>();
			ParallelBenchmark.Benchmark(dict3, dictSize);
		}
	}
}
