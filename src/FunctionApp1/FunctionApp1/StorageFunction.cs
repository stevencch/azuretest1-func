// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using System;
using System.Text.Json;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class StorageFunction
    {
        private readonly ILogger<StorageFunction> _logger;

        public StorageFunction(ILogger<StorageFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(StorageFunction))]
        public void Run([EventGridTrigger] EventGridEvent cloudEvent)
        {
            _logger.LogInformation("Event type: {type}, Event subject: {subject},Event Data: {data}", 
                cloudEvent.Topic, cloudEvent.Subject, cloudEvent.Data);
        }
    }
}
