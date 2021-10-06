using Akka.Actor;
using System.Threading.Tasks;

namespace AkkaWebAPI
{
    public interface ICalculatorActorInstance
    {
        Task<AnswerMessage> Sum(AddMessage message);
    }

    public class CalculatorActorInstance : ICalculatorActorInstance
    {
        private IActorRef _actor;

        public CalculatorActorInstance(ActorSystem actorSystem)
        {
            _actor = actorSystem.ActorOf(Props.Create<CalculatorActor>(), "calculator");
        }

        public async Task<AnswerMessage> Sum(AddMessage message)
        {
            return await _actor.Ask<AnswerMessage>(message);
        }
    }
}
