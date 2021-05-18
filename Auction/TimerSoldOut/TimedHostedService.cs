using System;
using System.Threading;
using System.Threading.Tasks;
using Auction.DataBaseConnection;
using Auction.DataBaseConnection.Factory;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Auction.TimerSoldOut
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(SoldOutTimer,null, TimeSpan.Zero, 
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }
        

        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
        public static void SoldOutTimer(object? state)
        {
            int lotId;
            string endOfAuctionDate;
            DateTime lotdateTime = new DateTime();
            foreach (var idAndDate in Factory.GetEndOfAuctionDate(DatabaseConnection.GetEndOfAuctionDate()))
            {
                lotId = idAndDate.Item1;
                endOfAuctionDate = idAndDate.Item2;
                lotdateTime = DateTime.ParseExact(endOfAuctionDate, "yyyy-M-dd", null);
                if (lotdateTime <= DateTime.Today)
                {
                    var profileIdAndMaxBet = Factory.GetProfileIdAndMaxBet(DatabaseConnection.GetProfileIdAndMaxBet(lotId));
                    Factory.UpdateLotOwners(profileIdAndMaxBet.Item1,lotId);
                    Factory.UpdateLotSodlOut(lotId);
                    Console.WriteLine("Сработало");
                }
                else
                {
                    Console.WriteLine("Не робит");
                }
            }
        }
    }
}