using Confluent.Kafka;
using System.Text.Json;

namespace Inator.Messaging.Integration.Producers
{
    public class Producer : Producers.IProducer
    {
        private readonly IProducer<string, string> producer;

        public Producer(ProducerSettings parameters)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = parameters.Server,
            };

            producer = new ProducerBuilder<string, string>(config).Build();

        }
        public async Task Produce<T>(ProducerParams<T> parameters, Action<Exception> onError)
        {
            try
            {
                var dr = await producer.ProduceAsync(parameters.Topic, new Message<string, string> { Key = parameters.OrderKey, Value = JsonSerializer.Serialize(parameters.Data) });
                Console.WriteLine($"Delivered '{dr.Key}' to '{dr.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                onError(e);
            }
        }
    }
}
