using DesignPatternsNet.Behavioral.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediatorController : ControllerBase
    {
        private static readonly Component1 _component1 = new Component1();
        private static readonly Component2 _component2 = new Component2();
        private static readonly ConcreteMediator _mediator = new ConcreteMediator(_component1, _component2);

        [HttpGet("event/{eventType}")]
        public IActionResult TriggerEvent(string eventType)
        {
            string message;

            switch (eventType.ToUpper())
            {
                case "A":
                    _component1.DoA();
                    message = "Component 1 triggered event A";
                    break;
                case "B":
                    _component1.DoB();
                    message = "Component 1 triggered event B";
                    break;
                case "C":
                    _component2.DoC();
                    message = "Component 2 triggered event C";
                    break;
                case "D":
                    _component2.DoD();
                    message = "Component 2 triggered event D";
                    break;
                default:
                    return BadRequest(new
                    {
                        Message = $"Unknown event type: {eventType}. Use A, B, C, or D."
                    });
            }

            return Ok(new
            {
                EventType = eventType.ToUpper(),
                EventLog = _mediator.GetEventLog(),
                Message = message
            });
        }

        [HttpGet("log")]
        public IActionResult GetEventLog()
        {
            return Ok(new
            {
                EventLog = _mediator.GetEventLog(),
                Message = "Event log retrieved."
            });
        }
    }
}
