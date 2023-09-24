using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SBQueueDemo
{
    public class SBQueueTriggerFunction
    {
        private readonly ILogger<SBQueueTriggerFunction> _logger;

        public SBQueueTriggerFunction(ILogger<SBQueueTriggerFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(SBQueueTriggerFunction))]
        public void Run([ServiceBusTrigger("funcappsbqueuetrigger", Connection = "ServiceBusConnectionString")] ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);
        }
    }
}
