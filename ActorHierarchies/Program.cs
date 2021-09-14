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
            dispatcher.Tell(new PlaySongMessage("Another brock in the wall", "Mike"));

            dispatcher.Tell(new StopPlayingMessage("Jhon"));
            dispatcher.Tell(new StopPlayingMessage("Mike"));

            dispatcher.Tell(new StopPlayingMessage("Mike"));
            Console.Read();

            system.Terminate();
        }
    }
}
