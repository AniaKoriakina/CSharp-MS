using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQRpcService
{
    public class RpcServer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RpcServer()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("rpc_queue", false, false, false, null);
            _channel.BasicQos(0, 1, false);
        }

        public void Start()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var props = ea.BasicProperties;
                var replyProps = _channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                string response = null;

                var message = Encoding.UTF8.GetString(body);
                response = $"Echo: {message}";

                var responseBytes = Encoding.UTF8.GetBytes(response);

                _channel.BasicPublish(
                    exchange: "",
                    routingKey: props.ReplyTo,
                    basicProperties: replyProps,
                    body: responseBytes
                );

                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume("rpc_queue", false, consumer);
        }

        public void Stop()
        {
            _connection.Close();
        }
    }
}
