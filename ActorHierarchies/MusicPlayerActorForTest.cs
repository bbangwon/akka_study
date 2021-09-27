using System;
using Akka.Actor;

namespace ActorHierarchies
{
    public class MusicPlayerActorForTest : ReceiveActor
    {
        protected PlaySongMessage CurrentSong;
        public MusicPlayerActorForTest()
        {
            Receive<PlaySongMessage>(PlaySong);
        }

        private void PlaySong(PlaySongMessage message)
        {
            CurrentSong = message;
            Console.WriteLine($"{CurrentSong.User} is currently listening to '{CurrentSong.Song}");
        }

    }
}
