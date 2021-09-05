using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SubmitOrders
{
	class Program
	{
		static void Main(string[] args)
		{
			var ordersQueue = new ConcurrentQueue<string>();
			Task task1 = Task.Run(()=>PlaceOrders(ordersQueue, "Xavier", 5));
			Task task2 = Task.Run(()=>PlaceOrders(ordersQueue, "Ramdevi", 5));

			Task.WaitAll(task1, task2);

			foreach (string order in ordersQueue)
				Console.WriteLine("ORDER: " + order);
		}

		static void PlaceOrders(ConcurrentQueue<string> orders, string customerName, int nOrders)
		{
			for (int i = 1; i <= nOrders; i++)
			{
				Thread.Sleep(1);
				string orderName = $"{customerName} wants t-shirt {i}";
				orders.Enqueue(orderName);
			}
		}
	}
}