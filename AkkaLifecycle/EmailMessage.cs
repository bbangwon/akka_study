namespace AkkaLifecycle
{
    public class EmailMessage
    {
        public EmailMessage(string from, string to, string content)
        {
            this.From = from;
            this.To = to;
            this.Content = content;
        }

        public string From { get; }
        public string To { get; }
        public string Content { get; }
    }
}
