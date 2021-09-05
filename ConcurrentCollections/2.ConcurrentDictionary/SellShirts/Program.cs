using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pluralsight.ConcurrentCollections.SellShirts
{
	class Program
	{
		static void Main(string[] args)
		{
			StockController controller = new StockController(TShirtProvider.AllShirts);
			TimeSpan workDay = new TimeSpan(0, 0, 0, 0, 500);

			Task task1 = Task.Run(()=>new SalesPerson("Kim").Work(workDay, controller));
			Task task2 = Task.Run(() => new SalesPerson("Sahil").Work(workDay, controller));
			Task task3 = Task.Run(() => new SalesPerson("Chuck").Work(workDay, controller));

			Task.WaitAll(task1, task2, task3);

			controller.DisplayStock();
		}
	}
}
