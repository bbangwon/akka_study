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

            EmailMessage invalidEmail = new EmailMessage("from@mail.com", "to@mail.com", null);
            EmailMessage validEmail = new EmailMessage("from@mail.com", "to@mail.com", "Hi");            

            emailSender.Tell(validEmail);
            emailSender.Tell(invalidEmail);
            emailSender.Tell(validEmail);

            Console.Read();
            system.Terminate();
        }
    }
}
