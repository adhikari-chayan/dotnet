using System;
using System.Threading.Tasks;

namespace Pluralsight.ConcurrentCollections.BuyAndSell
{
    class Program
	{
		static void Main(string[] args)
		{
			StockController controller = new StockController();
			TimeSpan workDay = new TimeSpan(0, 0, 0, 0, 500);

			Task task1= Task.Run(()=>new SalesPerson("Tim").Work(workDay, controller));
			Task task2 = Task.Run(() => new SalesPerson("Koffi").Work(workDay, controller));
			Task task3 = Task.Run(() => new SalesPerson("Julie").Work(workDay, controller));
			Task task4 = Task.Run(() => new SalesPerson("Michael").Work(workDay, controller));

			Task.WaitAll(task1, task2, task3, task4);

			controller.DisplayStock();
		}
	}
}