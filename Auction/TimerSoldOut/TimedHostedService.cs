using System;
using System.Data.Entity.Core.Metadata.Edm;
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
                TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
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
                    for (int i = 0; i < profileIdAndMaxBet.Count; i++)
                    {
                        //Factory.GetProfileBalanace(DatabaseConnection.GetProfileBalanace(profileIdAndMaxBet[i].Item1)) >=
                        //profileIdAndMaxBet[i].Item2 || 
                        // if (profileIdAndMaxBet[i].Item1 ==
                        //     Factory.GetLotOwnerId(DatabaseConnection.GetLotOwnerId(lotId)))
                        // {
                            if (profileIdAndMaxBet[i].Item1 ==
                                Factory.GetLotOwnerId(DatabaseConnection.GetLotOwnerId(lotId)))
                            {
                                Factory.UpdateLotOwners(profileIdAndMaxBet[i].Item1,lotId);
                                Factory.UpdateLotSodlOut(lotId);
                                Console.WriteLine("Лот вернулся создателю");
                            }
                            else
                            {
                                
                                Factory.UpdateLotOwners(profileIdAndMaxBet[i].Item1,lotId);
                                Factory.UpdateLotSodlOut(lotId);
                                Factory.UpdateProfileBalanace(profileIdAndMaxBet[i].Item1,(Factory.GetProfileBalanace(DatabaseConnection.GetProfileBalanace(profileIdAndMaxBet[i].Item1))-profileIdAndMaxBet[i].Item2));
                                profileIdAndMaxBet.RemoveAt(i);
                                for (int j = 0; j < profileIdAndMaxBet.Count; j++)
                                {
                                    if(profileIdAndMaxBet[j].Item1 !=
                                       Factory.GetLotOwnerId(DatabaseConnection.GetLotOwnerId(lotId)))
                                    Factory.UpdateProfileBalanace(profileIdAndMaxBet[j].Item1,(Factory.GetProfileBalanace(DatabaseConnection.GetProfileBalanace(profileIdAndMaxBet[j].Item1))+profileIdAndMaxBet[j].Item2));
                                }
                                break;
                            }
                        // }
                        // else
                        // {
                        //     Console.WriteLine("Баланса нет");
                        // }
                    }
                }
                else
                {
                    Console.WriteLine("Не робит");
                }
            }
        }
    }
}