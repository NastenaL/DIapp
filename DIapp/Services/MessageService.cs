namespace DIapp.Services
{
    public class MessageService
    {
        IMessageSender sender;
        public MessageService(IMessageSender sender)
        {
            this.sender = sender;
        }

        public string Send()
        {
            return sender.Send();
        }
    }
}
