using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            const string queueName = "testqueue";

            try
            {
                var connectionFactory = new ConnectionFactory()
                {
                    HostName = "ec2-13-126-67-188.ap-south-1.compute.amazonaws.com",
                    UserName = "admin",
                    Password = "password",
                    Port = 5672,
                    RequestedConnectionTimeout = TimeSpan.FromMilliseconds(3000) // milliseconds
                };

                using (var rabbitConnection = connectionFactory.CreateConnection())
                {
                    using (var channel = rabbitConnection.CreateModel())
                    {
                        // Declaring a queue is idempotent 
                        channel.QueueDeclare(
                            queue: queueName,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        while (true)
                        {
                            string body = $"A nice random message: {DateTime.Now.Ticks}";
                            channel.BasicPublish(
                                exchange: string.Empty,
                                routingKey: queueName,
                                basicProperties: null,
                                body: Encoding.UTF8.GetBytes(body));

                            Console.WriteLine("Message sent");
                            Task.Delay(500);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("End");
            Console.Read();
        }

    }
}
