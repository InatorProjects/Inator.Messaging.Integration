namespace Inator.Messaging.Integration.Producers
{
    public record ProducerParams
    {
        public string Server { get; set; }


        public ProducerParams(string server)
        {
            Server = server;
        }
    }
}
