using EventBus0032.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventBus0032.RabbitMQ
{
    public class RabbitMQEventBus : IEventBus
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public RabbitMQEventBus(IConnection connection, IServiceProvider serviceProvider)
        {
            _connection = connection;
            _serviceProvider = serviceProvider;
            _channel = _connection.CreateModel();

            // Declare the exchange
            _channel.ExchangeDeclare(exchange: "EventBusExchange", type: ExchangeType.Direct, durable: true);
        }

        public void Publish<T>(T @event) where T : class
        {
            var eventName = @event.GetType().Name;
            var message = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(message);

            try
            {
                _channel.BasicPublish(
                    exchange: "EventBusExchange",
                    routingKey: eventName,
                    basicProperties: null,
                    body: body);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Publish failed: {ex.Message}");
            }
        }

        public void Subscribe<T, TH>()
            where T : class
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            _channel.QueueDeclare(queue: eventName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: eventName, exchange: "EventBusExchange", routingKey: eventName);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                try
                {
                    var @event = JsonSerializer.Deserialize<T>(message);
                    using var scope = _serviceProvider.CreateScope();
                    var handler = scope.ServiceProvider.GetRequiredService<TH>();

                    if (handler != null)
                    {
                        await handler.Handle(@event);
                        _channel.BasicAck(ea.DeliveryTag, false); // Acknowledge message
                    }
                }
                catch (Exception ex)
                {
                    // Log and handle errors
                    Console.WriteLine($"Error handling message: {ex.Message}");
                }
            };

            _channel.BasicConsume(queue: eventName, autoAck: false, consumer: consumer);
        }
    }

    }
