using RabbitMQ.Client;
using System.Text;

namespace HRSystem.Common.MessageBroker
{
    public class RabbitMqPublisher
    {
        IConnection _connection;
        IChannel _channel;

        public RabbitMqPublisher()
        {
            var factory = new ConnectionFactory { HostName="localhost"};
            _connection = factory.CreateConnectionAsync().Result;
            _channel = _connection.CreateChannelAsync().Result;

            _channel.ExchangeDeclareAsync("AmazonSpecific", ExchangeType.Fanout, durable: true, autoDelete: false);
            _channel.QueueDeclareAsync("NewQueue",durable: true, autoDelete: false);

            _channel.QueueBindAsync("NewQueue", "newExchange", "key1");
        }

        public async Task PublishMessage(string message)
        {
            var body= Encoding.UTF8.GetBytes(message);
            await _channel.BasicPublishAsync("AmazonSpecific", "key1", body);
        }
    }
}
