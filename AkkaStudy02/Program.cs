using Akka.Actor;
using System;

namespace AkkaStudy02
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            Props typedActorProps = Props.Create<MyTypedActor>();
            Props untypedActorProps = Props.Create<MyUntypedActor>();

            IActorRef typedActor = system.ActorOf(typedActorProps);
            IActorRef untypedActor = system.ActorOf(untypedActorProps);

            /*
            IActorRef typedActor = system.ActorOf<MyTypedActor>();
            IActorRef untypedActor = system.ActorOf<MyUntypedActor>();
            */
        }
    }
}
