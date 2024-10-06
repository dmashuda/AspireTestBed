using System.Threading.Tasks;
using CustomerContracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CustomerWorker;

public class ConsumeMyMessage: IConsumer<MyMessage>
{
    readonly ILogger<ConsumeMyMessage> _logger;

    public ConsumeMyMessage(ILogger<ConsumeMyMessage> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MyMessage> context)
    {
        _logger.LogInformation($"Consumed message: {context.Message.Message}");
        return Task.CompletedTask;
    }
}