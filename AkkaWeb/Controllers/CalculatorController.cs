using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AkkaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {/*
        private ActorSystem _actorSystem;

        public CalculatorController(ActorSystem actorSystem)
        {
            _actorSystem = actorSystem;
        }
        */

        /*
        [HttpGet("sum")]
        public async Task<double> Sum(double x, double y)
        {
            var calculatorActorProps = Props.Create<CalculatorActor>();
            var calculatorRef = _actorSystem.ActorOf(calculatorActorProps);

            AddMessage addMessage = new AddMessage(x, y);
            AnswerMessage answer = await calculatorRef.Ask<AnswerMessage>(addMessage);

            return answer.Value;
        }
        */

        /*
        [HttpGet("sum")]
        public async Task<double> Sum(double x, double y)
        {
            IActorRef calculatorRef;
            try
            {
                calculatorRef = await _actorSystem.ActorSelection("/user/calculator").ResolveOne(TimeSpan.FromMilliseconds(100));
            }
            catch (ActorNotFoundException)
            {
                var calculatorActorProps = Props.Create<CalculatorActor>();
                calculatorRef = _actorSystem.ActorOf(calculatorActorProps, "calculator");
            }

            AddMessage addMessage = new AddMessage(x, y);
            AnswerMessage answer = await calculatorRef.Ask<AnswerMessage>(addMessage);
            return answer.Value;
        }
        */

        private readonly ICalculatorActorInstance CalculatorActor;

        public CalculatorController(ICalculatorActorInstance calculatorActor)
        {
            CalculatorActor = calculatorActor;
        }

        [HttpGet("sum")]
        public async Task<double> Sum(double x, double y)
        {
            var answer = await CalculatorActor.Sum(new AkkaRemoteCommon.AddMessage(x, y));

            return answer.Value;
        }
    }
}
