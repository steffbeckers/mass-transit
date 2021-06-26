using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Consumers
{
    public class SubmitOrderConsumer : IConsumer<SubmitOrder>
    {
        private readonly ILogger<SubmitOrderConsumer> _logger;

        public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SubmitOrder> context)
        {
            _logger.LogInformation($"SubmitOrderConsumer is processing order: {context.Message.Number}");

            return Task.CompletedTask;
        }
    }
}