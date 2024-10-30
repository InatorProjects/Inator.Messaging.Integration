namespace Inator.Messaging.Integration
{
    public interface IConsumerSettings
    {
        public String Topic { get; }

        public Action<String> Consume { get; }
    }
}
