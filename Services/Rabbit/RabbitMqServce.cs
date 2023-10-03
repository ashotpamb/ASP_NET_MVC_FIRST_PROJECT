using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CherryShop.Services.Rabbit
{

    public class RabbitMqService
    {
        private readonly ConnectionFactory _connectonFactory;
        private readonly IConnection _connection;

        private readonly IModel _channel;

        private string _queueName;
        private string _message;
        private string _replayQueue;


        public RabbitMqService(string queueName, string replayQueue, string message)
        {

            var host = "127.0.0.1";
            var user = "root";
            var password = "root";

            _queueName = queueName;
            _message = message;
            _replayQueue = replayQueue;


            _connectonFactory = new ConnectionFactory() { HostName = host, UserName = user, Password = password };
            _connection = _connectonFactory.CreateConnection();
            _channel = _connection.CreateModel();

        }

        public void CreateQueue(string queueName)
        {
            _channel.QueueDeclare(queue: queueName, exclusive: false);
        }

        public void SendAndReceiveMessage(Action<string> replayMessageCallback)
        {
            var consumer = new EventingBasicConsumer(_channel);

            var replayQueue = _channel.QueueDeclare(queue: _replayQueue, exclusive: false);

            _channel.QueueDeclare(_queueName, exclusive: false);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                replayMessageCallback(message);
                Console.WriteLine($"Replay recived {message}");

            };

            _channel.BasicConsume(queue: replayQueue.QueueName, autoAck: true, consumer: consumer);

            var message = _message;

            var body = Encoding.UTF8.GetBytes(message);

            var properties = _channel.CreateBasicProperties();

            properties.ReplyTo = replayQueue.QueueName;

            properties.CorrelationId = Guid.NewGuid().ToString();

            _channel.BasicPublish("", _queueName, properties, body);
        }

        public async Task<string> getReplayMessage()
        {
            var tcs = new TaskCompletionSource<string>();
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var responseMessage = Encoding.UTF8.GetString(body);
                tcs.TrySetResult(responseMessage);
            };

            // var replyQueueName = _channel.QueueDeclare().QueueName;

            _channel.BasicConsume(queue: "consume", autoAck: true, consumer: consumer);

            return await tcs.Task;
        }

        public void CloseConnecton()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}