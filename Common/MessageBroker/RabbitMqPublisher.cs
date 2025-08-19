using RabbitMQ.Client;
using System.Text;

namespace HRSystem.Common.MessageBroker
{
    public class RabbitMqPublisher:IAsyncDisposable
    {
        IConnection _connection;
        IChannel _channel;

        public RabbitMqPublisher()
        {
         
        }


        public async Task PublishMessage(string message)
        {
            var body= Encoding.UTF8.GetBytes(message);
            await _channel.BasicPublishAsync("AmazonSpecific", "key1", body);
        }

        public async Task InitAsync()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            await _channel.ExchangeDeclareAsync("AmazonSpecific", ExchangeType.Fanout, durable: true, autoDelete: false);
            await _channel.QueueDeclareAsync("NewQueue", durable: true, autoDelete: false);

            await _channel.QueueBindAsync("NewQueue", "AmazonSpecific", "");
        }

        public async ValueTask DisposeAsync()
        {
            if (_channel != null) await _channel.DisposeAsync();
            if (_connection != null) await _connection.DisposeAsync();
        }
    }
}
