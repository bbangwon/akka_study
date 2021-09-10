using Akka.Actor;

namespace AkkaDI
{
    public class MusicActor : ReceiveActor
    {
        private IMusicSongService SongService { get; }
        public MusicActor(IMusicSongService songService)
        {
            this.SongService = songService;
            Receive<string>(s => HandleSongRetrieval(s));
        }

        private void HandleSongRetrieval(string songName)
        {
            var song = SongService.GetSongByName(songName);            
        }
    }
}
