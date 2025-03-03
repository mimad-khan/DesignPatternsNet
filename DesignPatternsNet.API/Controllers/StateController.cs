using DesignPatternsNet.Behavioral.State;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StateController : ControllerBase
    {
        private static readonly Context _context = new Context(new ConcreteStateA());

        [HttpGet]
        public IActionResult GetState()
        {
            return Ok(new
            {
                CurrentState = _context.GetCurrentState().GetStateName(),
                StateHistory = _context.GetStateHistory(),
                Message = "Current state retrieved."
            });
        }

        [HttpPost("request")]
        public IActionResult MakeRequest()
        {
            var previousState = _context.GetCurrentState().GetStateName();
            
            // Trigger a state transition
            _context.Request();
            
            var currentState = _context.GetCurrentState().GetStateName();

            return Ok(new
            {
                PreviousState = previousState,
                CurrentState = currentState,
                StateHistory = _context.GetStateHistory(),
                Message = $"State transitioned from {previousState} to {currentState}."
            });
        }

        [HttpPost("cycle")]
        public IActionResult CompleteCycle()
        {
            var initialState = _context.GetCurrentState().GetStateName();
            var stateTransitions = new System.Collections.Generic.List<string>();
            
            // Complete a full cycle of state transitions (A -> B -> C -> A)
            for (int i = 0; i < 3; i++)
            {
                var previousState = _context.GetCurrentState().GetStateName();
                _context.Request();
                var currentState = _context.GetCurrentState().GetStateName();
                
                stateTransitions.Add($"{previousState} -> {currentState}");
            }

            return Ok(new
            {
                InitialState = initialState,
                StateTransitions = stateTransitions,
                FinalState = _context.GetCurrentState().GetStateName(),
                StateHistory = _context.GetStateHistory(),
                Message = "Completed a full cycle of state transitions."
            });
        }
    }
}
