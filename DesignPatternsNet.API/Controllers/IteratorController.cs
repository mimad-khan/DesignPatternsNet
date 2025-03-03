using DesignPatternsNet.Behavioral.Iterator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IteratorController : ControllerBase
    {
        private static readonly ConcreteCollection<string> _collection = new ConcreteCollection<string>();

        static IteratorController()
        {
            // Initialize the collection with some items
            _collection.AddItem("Item 1");
            _collection.AddItem("Item 2");
            _collection.AddItem("Item 3");
            _collection.AddItem("Item 4");
            _collection.AddItem("Item 5");
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(new
            {
                Items = _collection.GetItems(),
                Count = _collection.Count,
                Message = "Collection items retrieved."
            });
        }

        [HttpPost("add/{item}")]
        public IActionResult AddItem(string item)
        {
            _collection.AddItem(item);
            return Ok(new
            {
                Items = _collection.GetItems(),
                Count = _collection.Count,
                Message = $"Item '{item}' added to the collection."
            });
        }

        [HttpGet("iterate/forward")]
        public IActionResult IterateForward()
        {
            var iterator = _collection.CreateIterator();
            var items = new List<string>();

            while (iterator.HasNext())
            {
                items.Add(iterator.Next());
            }

            return Ok(new
            {
                Items = items,
                Direction = "Forward",
                Message = "Collection iterated in forward direction."
            });
        }

        [HttpGet("iterate/reverse")]
        public IActionResult IterateReverse()
        {
            var iterator = _collection.CreateReverseIterator();
            var items = new List<string>();

            while (iterator.HasNext())
            {
                items.Add(iterator.Next());
            }

            return Ok(new
            {
                Items = items,
                Direction = "Reverse",
                Message = "Collection iterated in reverse direction."
            });
        }

        [HttpGet("iterate/both")]
        public IActionResult IterateBoth()
        {
            var forwardIterator = _collection.CreateIterator();
            var reverseIterator = _collection.CreateReverseIterator();
            
            var forwardItems = new List<string>();
            var reverseItems = new List<string>();

            while (forwardIterator.HasNext())
            {
                forwardItems.Add(forwardIterator.Next());
            }

            while (reverseIterator.HasNext())
            {
                reverseItems.Add(reverseIterator.Next());
            }

            return Ok(new
            {
                ForwardItems = forwardItems,
                ReverseItems = reverseItems,
                Message = "Collection iterated in both directions."
            });
        }
    }
}
