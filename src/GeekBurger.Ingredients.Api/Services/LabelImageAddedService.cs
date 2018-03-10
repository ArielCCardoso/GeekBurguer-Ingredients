using GeekBurger.Ingredients.Api.Models;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeekBurger.Ingredients.Api.Services
{
    public class LabelImageAddedService : ILabelImageAddedService
    {
        private QueueClient _queueClient;

        private readonly string _connectionString;
        private readonly string _quereName;
        private static List<Task> PendingCompleteTasks;

        public LabelImageAddedService(Configuration  configuration)
        {
            _connectionString = configuration.ServiceBus.ConnectionString;
            _quereName = configuration.ServiceBus.Path;
        }

        public async Task ReceiveMessage()
        {
            PendingCompleteTasks = new List<Task>();

            _queueClient = new QueueClient(_connectionString, _quereName, ReceiveMode.PeekLock);

            var handlerOptions = new MessageHandlerOptions(ExceptionHandler) { AutoComplete = false, MaxConcurrentCalls = 3 };

            _queueClient.RegisterMessageHandler(MessageHandler, handlerOptions);

            await Task.WhenAll(PendingCompleteTasks);

            await _queueClient.CloseAsync();
        }

        private async Task MessageHandler(Message message, CancellationToken cancellationToken)
        {
            if (_queueClient.IsClosedOrClosing)
                return;

            string messageBody = Encoding.UTF8.GetString(message.Body);

            Label label = JsonConvert.DeserializeObject<Label>(messageBody);

            Thread.Sleep(1500); // process message

            Task PendingCompleteTask;
            lock (PendingCompleteTasks)
            {
                PendingCompleteTasks.Add(_queueClient.CompleteAsync(message.SystemProperties.LockToken));
                PendingCompleteTask = PendingCompleteTasks.LastOrDefault();
            }

            await PendingCompleteTask;

            PendingCompleteTasks.Remove(PendingCompleteTask);
        }

        private Task ExceptionHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Message handler encountered an exception { arg.Exception}.");

            var context = arg.ExceptionReceivedContext;

            Console.WriteLine($"- Endpoint: {context.Endpoint}, Path: { context.EntityPath}, Action: { context.Action}");

            return Task.CompletedTask;
        }
    }
}
