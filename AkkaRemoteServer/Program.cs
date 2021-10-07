using Akka.Actor;
using AkkaRemoteCommon;
using System;

namespace AkkaRemoteServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var hocon = HoconLoader.FromFile("akka.net.hocon");
            ActorSystem system = ActorSystem.Create("server-system", hocon);

            Console.WriteLine("Server started");

            Console.Read();
            system.Terminate().Wait();
        }
    }
}
