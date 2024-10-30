namespace Inator.Messaging.Integration.Producers
{
    public interface IProducer
    {
        Task Produce<T>(ProducerParams<T> parameters, Action<Exception> onError);
    }
}
