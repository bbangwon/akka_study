using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Event;

namespace BookPublisher
{
    public class DeadLetterMonitor : ReceiveActor
    {
        public DeadLetterMonitor()
        {
            Receive<DeadLetter>(Handle);
        }

        private void Handle(DeadLetter deadLetter)
        {
            var msg = $"message: {deadLetter.Message}, \n" +
                $"sender: {deadLetter.Sender}, \n" +
                $"recipient: {deadLetter.Recipient}\n";

            Console.WriteLine(msg);                
        }
    }

    public class EchoActor : ReceiveActor { }
}
