using System;
using Akka.Actor;

namespace AkkaFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc();
        }

        static void First()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef untypedActor = system.ActorOf<MyUntypedActor>("untyped-actor-name");
            IActorRef typedActor = system.ActorOf<MyTypedActor>("typed-actor-name");

            untypedActor.Tell(new GreetingMessage("Hello untyped actor!"));
            typedActor.Tell(new GreetingMessage("Hello typed actor!"));

            Console.Read();
        }

        static void Calc()
        {
            ActorSystem system = ActorSystem.Create("calc-system");
            IActorRef calculator = system.ActorOf<CalculatorActor>("calculator");

            Answer result = calculator.Ask<Answer>(new Add(1, 2)).Result;

            Console.WriteLine("Addition result: " + result.Value);
            system.Terminate();
        }
    }
}
