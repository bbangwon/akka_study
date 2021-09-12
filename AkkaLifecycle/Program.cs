using System;
using System.Threading;
using Akka.Actor;

namespace AkkaLifecycle
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef emailSender = system.ActorOf<EmailSenderActor>("emailSender");
            EmailMessage emailMessage = new EmailMessage("from@mail.com", "to@mail.com", "Hi");            

            emailSender.Tell(emailMessage);
            var result = emailSender.GracefulStop(TimeSpan.FromSeconds(10));

            Thread.Sleep(1000);
            system.Terminate();
            Console.Read();
        }
    }
}
