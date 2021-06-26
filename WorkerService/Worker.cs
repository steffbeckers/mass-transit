using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int orderCounter = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                orderCounter++;

                await _bus.Publish(new SubmitOrder
                {
                    Number = "ORDER" + orderCounter.ToString().PadLeft(5, '0')
                });

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
