using System;
using Akka.Actor;
using Akka.Routing;

namespace AkkaRouters
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");
            var calculatorProps = Props.Create<CalculatorActor>()
                                    .WithRouter(new ConsistentHashingPool(4)
                                    .WithHashMapping(x =>
                                    {
                                        if(x is Add)
                                        {
                                            return ((Add)x).Term1;
                                        }
                                        return x;
                                    }));
                                    

            var calculatorRef = system.ActorOf(calculatorProps, "calculator");

            calculatorRef.Tell(new Add(100, 20));
            calculatorRef.Tell(new Add(100, 30));
            calculatorRef.Tell(new Add(12, 40));
            calculatorRef.Tell(new Add(100, 10));
            calculatorRef.Tell(new Add(14, 25));

            Console.Read();
            system.Terminate();
        }
    }
}
