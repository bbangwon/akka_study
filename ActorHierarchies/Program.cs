using Akka.Actor;
using System;

namespace ActorHierarchies
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");
            IActorRef dispatcher = system.ActorOf<MusicPlayerCoordinatorActor>("player-coordinator");

            dispatcher.Tell(new PlaySongMessage("Smoke on the water", "Jhon"));

            Console.Read();

            system.Terminate();
        }
    }
}
