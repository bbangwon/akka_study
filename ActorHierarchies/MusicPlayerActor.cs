using Akka.Actor;
using System;

namespace ActorHierarchies
{
    public class MusicPlayerActor : ReceiveActor
    {
        protected PlaySongMessage CurrentSong;

        public MusicPlayerActor()
        {
            StoppedBehaviour();
        }

        void StoppedBehaviour()
        {
            Receive<PlaySongMessage>(PlaySong);
            Receive<StopPlayingMessage>(m => Console.WriteLine($"{m.User}'s player: Cannot stop, the actor is already stopped"));
        }

        void PlayingBehaviour()
        {
            Receive<PlaySongMessage>(m => Console.WriteLine($"{CurrentSong.User}'s player: Cannot play. Currently playing '{CurrentSong}"));
            Receive<StopPlayingMessage>(StopPlaying);
        }

        void PlaySong(PlaySongMessage message)
        {
            CurrentSong = message;
            Console.WriteLine($"{CurrentSong.User} is Currently listening to '{CurrentSong.Song}'");

            DisplayInformation();

            var statsActor = Context.ActorSelection("../../statistics");
            statsActor.Tell(message);

            Become(PlayingBehaviour);
        }

        void StopPlaying(StopPlayingMessage message)
        {
            Console.WriteLine($"{CurrentSong.User}'s Player is currently stopped.");
            CurrentSong = null;
            Become(StoppedBehaviour);
        }

        void DisplayInformation()
        {
            Console.WriteLine("Actor's information:");
            Console.WriteLine($"Typed Actor named: {Self.Path.Name}");
            Console.WriteLine($"Actor's path: {Self.Path}");
            Console.WriteLine($"Actor is part of the ActorSystem: {Context.System.Name}");
            Console.WriteLine($"Actor's parent: {Context.Self.Path.Parent.Name}");
        }
    }
}
