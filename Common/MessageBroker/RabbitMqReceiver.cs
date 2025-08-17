using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HRSystem.Common.MessageBroker
{
    public class RabbitMqReceiver:IHostedService
    {
        IConnection _connection;
        IChannel _channel;
        public RabbitMqReceiver()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnectionAsync().Result;
            _channel = _connection.CreateChannelAsync().Result;

            _channel.ExchangeDeclareAsync("AmazonSpecific", ExchangeType.Fanout, durable: true, autoDelete: false);
            _channel.QueueDeclareAsync("NewQueue", durable: true, autoDelete: false);

            _channel.QueueBindAsync("NewQueue", "newExchange", "key1");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
