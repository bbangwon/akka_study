using Akka.Actor;
using System;
using System.Collections.Generic;

namespace ActorHierarchies
{
    public class SongPerformanceActor : ReceiveActor
    {
        public Dictionary<string, int> SongPerformanceCounter;

        public SongPerformanceActor()
        {
            SongPerformanceCounter = new Dictionary<string, int>();
            Receive<PlaySongMessage>(IncreaseSongCounter);
        }

        public void IncreaseSongCounter(PlaySongMessage m)
        {
            var counter = 1;
            if(SongPerformanceCounter.ContainsKey(m.Song))
            {
                counter = ++SongPerformanceCounter[m.Song];
            }
            else
            {
                SongPerformanceCounter.Add(m.Song, counter);
            }
            Console.WriteLine($"Song: {m.Song} has been played {counter} times");

            Sender.Tell(new CountIncreasedMessage(m.Song, counter));
        }
    }
}
