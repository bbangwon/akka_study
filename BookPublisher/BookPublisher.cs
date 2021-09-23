using Akka.Actor;


namespace BookPublisher
{
    public class BookPublisher : ReceiveActor
    {
        public BookPublisher()
        {
            Receive<NewBookMessage>(Handle);
        }

        private void Handle(NewBookMessage x)
        {
            Context.System.EventStream.Publish(x);
        }
    }
}
