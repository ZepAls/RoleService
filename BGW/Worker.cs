using System.Text;
using BGW.controllers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace BGW;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        MessageHandler handleMessage = new MessageHandler();

        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "RoleQueue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            _logger.LogInformation($" [x] Received {message}");
            handleMessage.IdentifyMessage(message);
        };

        while (!stoppingToken.IsCancellationRequested)
        {
            channel.BasicConsume(queue: "RoleQueue",
                                 autoAck: true,
                                 consumer: consumer);
            _logger.LogInformation(" [*] Waiting for messages.");
            await Task.Delay(1000, stoppingToken);
        }
    }
}
