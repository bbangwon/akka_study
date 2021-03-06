using System;
using Akka.Actor;

namespace AkkaSwitchableBehaviour
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef musicPlayer = system.ActorOf<MusicPlayerActor>("musicPlayer");

            musicPlayer.Tell(new PlaySongMessage("Smoke on the water"));
            musicPlayer.Tell(new PlaySongMessage("Another brick in the wall"));
            musicPlayer.Tell(new StopPlayingMessage());
            musicPlayer.Tell(new StopPlayingMessage());
            musicPlayer.Tell(new PlaySongMessage("Another brick in the wall"));

            Console.Read();
            system.Terminate();
        }
    }
}
