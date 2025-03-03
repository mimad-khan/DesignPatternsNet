using DesignPatternsNet.Behavioral.Memento;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MementoController : ControllerBase
    {
        private static readonly Originator _originator = new Originator("Initial state");
        private static readonly Caretaker _caretaker = new Caretaker(_originator);

        static MementoController()
        {
            // Save the initial state
            _caretaker.Backup();
        }

        [HttpGet]
        public IActionResult GetCurrentState()
        {
            return Ok(new
            {
                CurrentState = _originator.GetState(),
                History = _caretaker.ShowHistory(),
                HistoryCount = _caretaker.GetHistoryCount(),
                Message = "Current state retrieved."
            });
        }

        [HttpPost("update/{text}")]
        public IActionResult UpdateState(string text)
        {
            // Save the current state before making changes
            _caretaker.Backup();
            
            // Update the state
            _originator.DoSomething(text);

            return Ok(new
            {
                PreviousState = _caretaker.ShowHistory().LastOrDefault(),
                CurrentState = _originator.GetState(),
                History = _caretaker.ShowHistory(),
                HistoryCount = _caretaker.GetHistoryCount(),
                Message = $"State updated with '{text}'."
            });
        }

        [HttpPost("undo")]
        public IActionResult UndoState()
        {
            if (_caretaker.GetHistoryCount() <= 1)
            {
                return BadRequest(new
                {
                    Message = "Cannot undo. No more history available."
                });
            }

            var currentState = _originator.GetState();
            
            // Undo to the previous state
            _caretaker.Undo();

            return Ok(new
            {
                PreviousState = currentState,
                CurrentState = _originator.GetState(),
                History = _caretaker.ShowHistory(),
                HistoryCount = _caretaker.GetHistoryCount(),
                Message = "State reverted to the previous version."
            });
        }
    }
}
