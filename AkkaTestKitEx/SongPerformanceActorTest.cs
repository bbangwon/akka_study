using Akka.TestKit.NUnit3;
using NUnit.Framework;
using System.Linq;
using ActorHierarchies;


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

        [Test]
        public void ShouldIncreaseSongByOne()
        {
            var actor = new SongPerformanceActor();
            var songMessage = new PlaySongMessage("Bohemian Rhapsody", "Jhon");

            actor.IncreaseSongCounter(songMessage);
            Assert.True(actor.SongPerformanceCounter[songMessage.Song] == 1);
        }
    }
}
