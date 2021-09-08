using Akka.Actor;
using System;

namespace AkkaStudy02
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Main_3();
        }

        void Main_1()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            Props typedActorProps = Props.Create<MyTypedActor>();
            Props untypedActorProps = Props.Create<MyUntypedActor>();

            IActorRef typedActor = system.ActorOf(typedActorProps);
            IActorRef untypedActor = system.ActorOf(untypedActorProps);

            /*
            IActorRef typedActor = system.ActorOf<MyTypedActor>();
            IActorRef untypedActor = system.ActorOf<MyUntypedActor>();
            */
        }

        void Main_2()
        {
            ActorSystem system = ActorSystem.Create("html-download-system");

            IActorRef receiveAsyncActor = system.ActorOf<DownloadHtmlActor>("html-actor");
            receiveAsyncActor.Tell("https://www.microsoft.com");
            receiveAsyncActor.Tell("https://www.syncfusion.com");

            system.WhenTerminated.GetAwaiter().GetResult();
        }

        void Main_3()
        {
            ActorSystem system = ActorSystem.Create("html-download-system");
            IActorRef receiveAsyncActor = system.ActorOf<DownloadAnyHtmlActor>();

            receiveAsyncActor.Tell("https://www.microsoft.com");
            receiveAsyncActor.Tell(new Uri("https://www.syncfusion.com"));
            receiveAsyncActor.Tell(new GreetingMessage("hi"));

            Console.Read();
            system.Terminate();
        }
    }
}
