namespace AkkaStudy02
{
    public class GreetingMessage
    {
        public string Message { get; private set; }
        public GreetingMessage(string message)
        {
            this.Message = message;
        }
    }
}
