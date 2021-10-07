using System;
using Akka.Actor;

namespace AkkaRemoteCommon
{
    public class AddMessage
    {
        public AddMessage(double term1, double term2)
        {
            Term1 = term1;
            Term2 = term2;
        }
        public double Term1;
        public double Term2;
    }

    public class AnswerMessage
    {
        public AnswerMessage(double value)
        {
            Value = value;
        }

        public double Value;
    }
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<AddMessage>(add =>
            {
                Console.WriteLine($"{DateTime.Now}: Sum {add.Term1} + {add.Term2}");
                Sender.Tell(new AnswerMessage(add.Term1 + add.Term2));
            });
        }
    }
}
