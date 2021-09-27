namespace ActorHierarchies
{
    public class CountIncreasedMessage
    {
        public string Song;
        public long Count;

        public CountIncreasedMessage(string song, long count)
        {
            this.Song = song;
            this.Count = count;
        }
    }
}
