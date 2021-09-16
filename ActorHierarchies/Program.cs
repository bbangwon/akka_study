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
            var stats = system.ActorOf<SongPerformanceActor>("statistics");

            dispatcher.Tell(new PlaySongMessage("Smoke on the water", "Jhon"));
            dispatcher.Tell(new PlaySongMessage("Smoke on the water", "Mike"));
            dispatcher.Tell(new PlaySongMessage("Another Brick in the wall", "Andrew"));

            Console.Read();

            system.Terminate();
        }
    }
}
