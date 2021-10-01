using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace AkkaRouters
{
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<Add>(HandleAddition);
        }

        public void HandleAddition(Add add)
        {
            Console.WriteLine($"{Self.Path} received the request: {add.Term1}+{add.Term2}");

            if(!(Sender is DeadLetterActorRef))
                Sender.Tell(new Answer(add.Term1 + add.Term2));
        }
        
    }

    public class Answer
    {
        public Answer(double value)
        {
            this.Value = value;
        }

        public double Value;
    }

    public class Add
    {
        public Add(double term1, double term2)
        {
            this.Term1 = term1;
            this.Term2 = term2;
        }

        public double Term1;
        public double Term2;
    }
}
