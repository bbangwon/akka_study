using System;
using Akka.Actor;

namespace AkkaFirst
{
    public class MyTypedActor : ReceiveActor
    {
        public MyTypedActor()
        {
            Receive<GreetingMessage>(GreetingMessageHandler);
        }

        void GreetingMessageHandler(GreetingMessage greeting)
        {
            Console.WriteLine($"Typed Actor name: {Self.Path.Name}");
            Console.WriteLine($"Received a greeting: {greeting.Greeting}");
            Console.WriteLine($"Actor's Path: {Self.Path}");
            Console.WriteLine($"Actor is part of the ActorSystem: {Context.System.Name}");
        }
    }
}
