﻿using GeekBurger.Ingredients.Api.Events.Interfaces;
using GeekBurger.Ingredients.Api.Models;
using GeekBurger.Ingredients.Api.Services.Interfaces;
using GeekBurger.LabelLoader.Contract;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeekBurger.Ingredients.Api.Events
{
    public class LabelImageReceived : ILabelImageReceived
    {
        private QueueClient _queueClient;
        private readonly string _connectionString;
        private readonly string _quereName;
        private readonly IProductService _productService;
        private static List<Task> PendingCompleteTasks;

        public LabelImageReceived(Configuration  configuration, IProductService productService)
        {
            _connectionString = configuration.ServiceBus.ConnectionString;
            _quereName = configuration.ServiceBus.Path;
            _productService = productService;
        }

        public async Task ProcessMessages()
        {
            PendingCompleteTasks = new List<Task>();

            _queueClient = new QueueClient(_connectionString, _quereName, ReceiveMode.PeekLock);

            var handlerOptions = new MessageHandlerOptions(ExceptionHandler) { AutoComplete = false, MaxConcurrentCalls = 3 };

            _queueClient.RegisterMessageHandler(MessageHandler, handlerOptions);

            await Task.WhenAll(PendingCompleteTasks);

            //await _queueClient.CloseAsync();
        }

        private async Task MessageHandler(Message message, CancellationToken cancellationToken)
        {
            if (_queueClient.IsClosedOrClosing)
                return;

            string messageBody = Encoding.UTF8.GetString(message.Body);

            TraceEvent(messageBody);

            var labelImageAddedOut = JsonConvert.DeserializeObject<ILabelImageAddedOut>(messageBody);

            var label = new Label
            {
                ItemName = labelImageAddedOut.ItemName,
                Ingredients = labelImageAddedOut.Ingredients
            };

            await _productService.Save(label);

            Task PendingCompleteTask;
            lock (PendingCompleteTasks)
            {
                PendingCompleteTasks.Add(_queueClient.CompleteAsync(message.SystemProperties.LockToken));
                PendingCompleteTask = PendingCompleteTasks.LastOrDefault();
            }

            await PendingCompleteTask;

            PendingCompleteTasks.Remove(PendingCompleteTask);
        }

        private void TraceEvent(string messageBody)
        {
            var context = new Dictionary<string, string>
            {
                { "message", messageBody }
            };

            var telemetryClient = new TelemetryClient();
            telemetryClient.TrackEvent("LabelReceived", context);
        }

        private Task ExceptionHandler(ExceptionReceivedEventArgs arg)
        {
            var context = new Dictionary<string, string>
            {
                { "Endpoint", arg.ExceptionReceivedContext.Endpoint },
                { "Path", arg.ExceptionReceivedContext.EntityPath },
                { "Action", arg.ExceptionReceivedContext.Action }
            };

            var telemetry = new TelemetryClient();
            telemetry.TrackException(arg.Exception);

            return Task.CompletedTask;
        }
    }
}
