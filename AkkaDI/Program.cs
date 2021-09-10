using System;
using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;

namespace AkkaDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MusicSongService>().As<IMusicSongService>();
            builder.RegisterType<MusicActor>().AsSelf();
            var container = builder.Build();

            var system = ActorSystem.Create("MySystem");
            var propsResolver = new AutoFacDependencyResolver(container, system);

            IActorRef musicAct = system.ActorOf(system.DI().Props<MusicActor>(), "MusicActor");
            musicAct.Tell("Bohamian Rhapsody");

            Console.Read();
            system.Terminate();
        }
    }
}
