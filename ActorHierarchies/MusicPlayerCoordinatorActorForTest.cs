using System.Collections.Generic;
using Akka.Actor;

namespace ActorHierarchies
{
    public class MusicPlayerCoordinatorActorForTest : ReceiveActor
    {
        protected Dictionary<string, IActorRef> MusicPlayerActors;

        public MusicPlayerCoordinatorActorForTest()
        {
            MusicPlayerActors = new Dictionary<string, IActorRef>();
            Receive<PlaySongMessage>(PlaySong);
        }

        private void PlaySong(PlaySongMessage message)
        {
            var musicPlayerActor = EnsureMusicPlayerActorExists(message.User);
            musicPlayerActor.Tell(message);
        }

        private IActorRef EnsureMusicPlayerActorExists(string user)
        {
            IActorRef musicPlayerActorRef;
            if(MusicPlayerActors.ContainsKey(user))
            {
                musicPlayerActorRef = MusicPlayerActors[user];
            }
            else
            {
                musicPlayerActorRef = Context.ActorOf<MusicPlayerActor>(user);
                MusicPlayerActors.Add(user, musicPlayerActorRef);
            }
            return musicPlayerActorRef;
        }
    }
}
