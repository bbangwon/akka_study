using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStudy02
{
    public class MyTypedActor : ReceiveActor
    {
        public MyTypedActor()
        {
            Receive<string>(message => Console.WriteLine(message));
        }
    }
}
