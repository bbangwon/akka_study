namespace AkkaDI
{
    public interface IMusicSongService
    {
        Song GetSongByName(string songName);
    }

    public class MusicSongService : IMusicSongService
    {
        public Song GetSongByName(string songName)
        {
            return new Song(songName, new byte[0]);
        }
    }

    public class Song
    {
        public Song(string songName, byte[] rowFormat)
        {
            this.SongName = songName;
            this.RowFormat = rowFormat;
        }

        public string SongName { get; }
        public byte[] RowFormat { get; }
    }
}
