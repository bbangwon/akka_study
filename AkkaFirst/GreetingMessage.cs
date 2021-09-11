namespace AkkaFirst
{
    public class GreetingMessage
    {
        public GreetingMessage(string greeting)
        {
            this.Greeting = greeting;
        }

        public string Greeting { get; }
    }
}
