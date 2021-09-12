using Akka.Actor;

namespace AkkaFirst
{
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<Add>(add => Sender.Tell(new Answer(add.Term1 + add.Term2)));
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
