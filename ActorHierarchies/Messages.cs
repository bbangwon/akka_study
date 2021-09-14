namespace ActorHierarchies
{
    public class PlaySongMessage
    {
        public PlaySongMessage(string song, string user)
        {
            this.Song = song;
            this.User = user;
        }
        public string Song { get; }
        public string User { get; }
    }

    public class StopPlayingMessage
    {
        public StopPlayingMessage(string user)
        {
            this.User = user;
        }

        public string User { get; }
    }
}
