using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace EnumerateDictionary
{
	class Program
	{
		static void Main(string[] args)
		{
			var stock = new ConcurrentDictionary<string, int>();
			stock.TryAdd("kcdc", 0);
			stock.TryAdd("Pluralsight Live 2018", 0);
			stock.TryAdd("docker", 0);

			foreach (var shirt in stock.ToArray())
			{
				stock["kcdc"] += 1; 
				Console.WriteLine(shirt.Key + ": " + shirt.Value);
			}
		}
	}
}
