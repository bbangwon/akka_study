using Akka.Actor;
using System.Collections.Generic;

namespace ActorHierarchies
{

    public class MusicPlayerCoordinatorActor : ReceiveActor
    {
        protected Dictionary<string, IActorRef> MusicPlayerActors;

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(e =>
            {
                if(e is SongNotAvailableException)
                {
                    return Directive.Resume;
                }
                else if(e is MusicSystemCorruptedException)
                {
                    return Directive.Restart;
                }
                else
                {
                    return Directive.Stop;
                }
            });
        }

        public MusicPlayerCoordinatorActor()
        {
            MusicPlayerActors = new Dictionary<string, IActorRef>();

            Receive<PlaySongMessage>(PlaySong);
            Receive<StopPlayingMessage>(StopPlaying);
        }

        void StopPlaying(StopPlayingMessage message)
        {
            var musicPlayerActor = GetMusicPlayerActor(message.User);
            if(musicPlayerActor != null)
            {
                musicPlayerActor.Tell(message);
            }
        }

        void PlaySong(PlaySongMessage message)
        {
            var musicPlayerActor = EnsureMusicPlayerActorExists(message.User);
            musicPlayerActor.Tell(message);
        }

        IActorRef EnsureMusicPlayerActorExists(string user)
        {
            IActorRef musicPlayerActorReference = GetMusicPlayerActor(user);
            if(musicPlayerActorReference == null)
            {
                musicPlayerActorReference = Context.ActorOf<MusicPlayerActor>(user);
                MusicPlayerActors.Add(user, musicPlayerActorReference);
            }
            return musicPlayerActorReference;
        }

        IActorRef GetMusicPlayerActor(string user)
        {
            IActorRef musicPlaterActorReference;
            MusicPlayerActors.TryGetValue(user, out musicPlaterActorReference);
            return musicPlaterActorReference;
        }
    }
}
