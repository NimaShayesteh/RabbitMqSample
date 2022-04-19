// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" , Port = 5672 };


using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "test1",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    string message = "Message From Sender";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "",
                         routingKey: "test1",
                         basicProperties: null,
                         body: body);
    Console.WriteLine(" [x] Sent {0}", message);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();