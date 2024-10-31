namespace Inator.Messaging.Integration.Producers
{
    public record ProducerSettings
    {
        public string Server { get; set; }


        public ProducerSettings(string server)
        {
            Server = server;
        }
    }
}
