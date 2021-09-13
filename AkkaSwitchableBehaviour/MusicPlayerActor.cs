using Akka.Actor;
using System;

namespace AkkaSwitchableBehaviour
{
    public class MusicPlayerActor : ReceiveActor
    {
        protected string CurrentSong;
        public MusicPlayerActor()
        {
            StoppedBehaviour();
        }

        private void StoppedBehaviour()
        {
            Receive<PlaySongMessage>(m => PlaySong(m.Song));
            Receive<StopPlayingMessage>(m => Console.WriteLine("Cannot stop, the actor is already stopped"));
        }

        private void PlayingBehaviour()
        {
            Receive<PlaySongMessage>(m => Console.WriteLine($"Cannot play. Currently playing '{CurrentSong}"));
            Receive<StopPlayingMessage>(m => StopPlaying());
        }

        void PlaySong(string song)
        {
            CurrentSong = song;
            Console.WriteLine($"Currently playing '{CurrentSong}");
            
            Become(PlayingBehaviour);
        }
        void StopPlaying()
        {
            CurrentSong = null;
            Console.WriteLine($"Player is currently stopped.");

            Become(StoppedBehaviour);
        }
    }
}
