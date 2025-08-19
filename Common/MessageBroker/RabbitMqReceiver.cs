using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

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

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += Consumer_ReceivedAsync;
           await _channel.BasicConsumeAsync("NewQueue", false, consumer);
        }

        private async Task Consumer_ReceivedAsync(object sender,BasicDeliverEventArgs @event)
        {
            try
            {
                var message = Encoding.UTF8.GetString(@event.Body.ToArray());
                //Console.WriteLine(message);
                var branc= Newtonsoft.Json.JsonConvert.DeserializeObject(message);
                await _channel.BasicAckAsync(@event.DeliveryTag, true);
            }

            catch (Exception ex) when( ex is NullReferenceException ) 
            {
                await _channel.BasicRejectAsync(@event.DeliveryTag, true);
            }
            catch(Exception ex)
            {
                await _channel.BasicRejectAsync(@event.DeliveryTag, false);
            }
          
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _channel.CloseAsync();
            await _connection.CloseAsync(); 
        }
    }
}
