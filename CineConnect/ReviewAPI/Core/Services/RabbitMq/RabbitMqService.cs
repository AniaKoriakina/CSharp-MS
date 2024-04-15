using Core.Services.Interfaces;
using Core.Services.RabbitMq.interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.RabbitMq
{
    public class RabbitMqService : IRabbitMqService, IMessageService
    {
        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "MyQueue",
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                               routingKey: "MyQueue",
                               basicProperties: null,
                               body: body);
            }
        }
        public string ReceiveMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "MyQueue",
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                var result = string.Empty;
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    result = Encoding.UTF8.GetString(body.ToArray());
                };
                channel.BasicConsume(queue: "MyQueue",
                                    autoAck: true,
                                    consumer: consumer);

                return result;
            }
        }

        public async Task SendMessageAsync(string message)
        {
            SendMessage(message);
            await Task.CompletedTask;
        }
    }
}
