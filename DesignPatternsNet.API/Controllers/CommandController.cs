using DesignPatternsNet.Behavioral.Command;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandController : ControllerBase
    {
        private static readonly Receiver _receiver = new Receiver();
        private static readonly Invoker _invoker = new Invoker();

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(new
            {
                Items = _receiver.GetItems(),
                CommandHistory = _invoker.GetCommandHistory(),
                CanUndo = _invoker.CanUndo(),
                Message = "Current state of the shopping list."
            });
        }

        [HttpPost("add/{item}")]
        public IActionResult AddItem(string item)
        {
            var command = new AddItemCommand(_receiver, item);
            _invoker.ExecuteCommand(command);

            return Ok(new
            {
                Items = _receiver.GetItems(),
                CommandExecuted = command.GetDescription(),
                CanUndo = _invoker.CanUndo(),
                Message = $"Item '{item}' added to the shopping list."
            });
        }

        [HttpPost("remove/{item}")]
        public IActionResult RemoveItem(string item)
        {
            var command = new RemoveItemCommand(_receiver, item);
            _invoker.ExecuteCommand(command);

            return Ok(new
            {
                Items = _receiver.GetItems(),
                CommandExecuted = command.GetDescription(),
                CanUndo = _invoker.CanUndo(),
                Message = $"Item '{item}' removed from the shopping list."
            });
        }

        [HttpPost("clear")]
        public IActionResult ClearItems()
        {
            var command = new ClearItemsCommand(_receiver);
            _invoker.ExecuteCommand(command);

            return Ok(new
            {
                Items = _receiver.GetItems(),
                CommandExecuted = command.GetDescription(),
                CanUndo = _invoker.CanUndo(),
                Message = "All items cleared from the shopping list."
            });
        }

        [HttpPost("undo")]
        public IActionResult UndoCommand()
        {
            if (!_invoker.CanUndo())
            {
                return BadRequest(new
                {
                    Message = "No commands to undo."
                });
            }

            var command = _invoker.Undo();

            return Ok(new
            {
                Items = _receiver.GetItems(),
                UndoneCommand = command.GetDescription(),
                RemainingCommands = _invoker.GetCommandHistory(),
                CanUndo = _invoker.CanUndo(),
                Message = "Last command was undone."
            });
        }
    }
}
