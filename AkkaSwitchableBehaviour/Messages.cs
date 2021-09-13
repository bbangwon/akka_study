namespace AkkaSwitchableBehaviour
{
    public class PlaySongMessage
    {
        public PlaySongMessage(string song)
        {
            this.Song = song;
        }
        public string Song { get; }        
    }

    public class StopPlayingMessage { }
}
