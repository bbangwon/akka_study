using Akka.TestKit.NUnit3;
using NUnit.Framework;
using System.Linq;
using ActorHierarchies;
using Akka.TestKit;
using System;

namespace AkkaTestKitEx
{
    [TestFixture]
    public class SongPerformanceActorTest : TestKit
    {
        [Test]
        public void ShouldStartWithAnEmptyState()
        {
            var actor = new SongPerformanceActor();

            Assert.False(actor.SongPerformanceCounter.Any());
        }

        /*
        [Test]
        public void ShouldIncreaseSongByOne()
        {
            var actor = new SongPerformanceActor();
            var songMessage = new PlaySongMessage("Bohemian Rhapsody", "Jhon");           
            
            actor.IncreaseSongCounter(songMessage);
            Assert.True(actor.SongPerformanceCounter[songMessage.Song] == 1);           
        }
        */

        [Test]
        public void ShouldIncreaseSongByOne()
        {
            TestActorRef<SongPerformanceActor> actor = ActorOfAsTestActorRef<SongPerformanceActor>();
            var songMessage = new PlaySongMessage("Bohemian Rhapsody", "John");

            actor.Tell(songMessage);
            Assert.True(actor.UnderlyingActor.SongPerformanceCounter[songMessage.Song] == 1);
        }

        [Test]
        public void ShouldResendCounterIncreasedMessage()
        {
            TestActorRef<SongPerformanceActor> actor = ActorOfAsTestActorRef<SongPerformanceActor>();
            var songMessage = new PlaySongMessage("Bohemian Rhapsody", "John");
            actor.Tell(songMessage);

            //var replyMessage = ExpectMsgFrom<CountIncreasedMessage>(actor);
            var counter = ExpectMsg<CountIncreasedMessage>(TimeSpan.FromSeconds(5));
            Assert.That(counter.Song == "Bohemian Rhapsody");
            Assert.That(counter.Count == 1);
        }
    }
}
