namespace Products.Api.Application.Common
{
    public class Message
    {
        public DateTime Timestamp { get; set; }

        public Message()
            => Timestamp = DateTime.Now;
    }
}
