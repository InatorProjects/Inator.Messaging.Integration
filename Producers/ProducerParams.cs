namespace Inator.Messaging.Integration.Producers
{
    public class MessageProductionParams<T>
    {
        public string Topic { get; private set; }
        public string OrderKey { get; private set; }
        public T Data { get; private set; }

        public MessageProductionParams(string topic, string orderKey, T data)
        {
            Topic = topic;
            OrderKey = orderKey;
            Data = data;
        }
    }
}
