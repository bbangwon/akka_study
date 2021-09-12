using System;
using Akka.Actor;

namespace AkkaLifecycle
{
    public class EmailSenderActor : ReceiveActor
    {
        public EmailSenderActor()
        {
            Console.WriteLine("Constructor() -> EmailSenderActor");
            Receive<EmailMessage>(HandleEmailMessage);
        }

        void HandleEmailMessage(EmailMessage message)
        {
            Console.WriteLine($"Email sent from {message.From} to {message.To}");
        }

        protected override void PreStart()
        {
            Console.WriteLine("PreStart() -> EmailSenderActor");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("PreRestart() -> EmailSenderActor");
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("PostRestart() -> EmailSenderActor");
            base.PostRestart(reason);
        }

        protected override void PostStop()
        {
            Console.WriteLine("PostStop() -> EmailSenderActor");
        }
    }
}
