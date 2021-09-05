using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Pluralsight.ConcurrentCollections.BuyAndSell
{
    public class LogTradesQueue
	{
		private BlockingCollection<Trade> _tradesToLog = new BlockingCollection<Trade>();
		private readonly StaffRecords _staffLogs;
		private bool _workingDayComplete;
		public LogTradesQueue(StaffRecords staffLogs)
		{
			_staffLogs = staffLogs;
		}
		public void SetNoMoreTrades() => _tradesToLog.CompleteAdding();
		public void QueueTradeForLogging(Trade trade) => _tradesToLog.TryAdd(trade);

		public void MonitorAndLogTrades()
		{
			while (true)
			{
				try
				{
					Trade nextTrade = _tradesToLog.Take();
					_staffLogs.LogTrade(nextTrade);
                    Console.WriteLine($"Processing transaction from {nextTrade.Person.Name}");
				}
				catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
					return;
                }
				
			}
		}
	}
}
