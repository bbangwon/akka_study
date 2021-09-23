using System;
using Akka.Actor;
using Akka.Event;

namespace BookPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ActorSystem system = ActorSystem.Create("pub-sub-example");

            var publisher = system.ActorOf<BookPublisher>("book-publisher");

            var subscriber1 = system.ActorOf<BookSubscriber>("book-subscriber1");
            var subscriber2 = system.ActorOf<BookSubscriber>("book-subscriber2");

            system.EventStream.Subscribe(subscriber1, typeof(NewBookMessage));
            system.EventStream.Subscribe(subscriber2, typeof(NewBookMessage));

            publisher.Tell(new NewBookMessage("Don Quixote"));
            publisher.Tell(new NewBookMessage("War and Peace"));

            Console.Read();
            system.Terminate();
            */

            ActorSystem system = ActorSystem.Create("dead-letter-example");

            var deadLetterSubscriber = system.ActorOf<DeadLetterMonitor>("dl-subscriber");
            var echoActor = system.ActorOf<EchoActor>("empty-echo-actor");

            system.EventStream.Subscribe(deadLetterSubscriber, typeof(DeadLetter));

            echoActor.Tell(PoisonPill.Instance);
            echoActor.Tell("Hello");
            Console.Read();

            system.Terminate();
        }
    }
}
