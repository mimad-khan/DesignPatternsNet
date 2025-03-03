using DesignPatternsNet.Behavioral.Observer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObserverController : ControllerBase
    {
        private static readonly Subject _subject = new Subject();
        private static readonly Dictionary<string, IObserver> _observers = new Dictionary<string, IObserver>();

        [HttpGet]
        public IActionResult GetState()
        {
            return Ok(new
            {
                SubjectState = _subject.State,
                Observers = GetObserversInfo(),
                Message = "Current state retrieved."
            });
        }

        [HttpPost("add/{type}/{name}")]
        public IActionResult AddObserver(string type, string name)
        {
            if (_observers.ContainsKey(name))
            {
                return BadRequest(new
                {
                    Message = $"Observer with name '{name}' already exists."
                });
            }

            IObserver observer;
            switch (type.ToLower())
            {
                case "a":
                    observer = new ConcreteObserverA(name);
                    break;
                case "b":
                    observer = new ConcreteObserverB(name);
                    break;
                default:
                    return BadRequest(new
                    {
                        Message = $"Unknown observer type: {type}. Use 'a' or 'b'."
                    });
            }

            _observers.Add(name, observer);
            _subject.Attach(observer);
            
            // Notify the observer about the current state
            observer.Update(_subject);

            return Ok(new
            {
                ObserverName = name,
                ObserverType = type.ToUpper(),
                Observers = GetObserversInfo(),
                Message = $"Observer '{name}' of type '{type}' added and notified."
            });
        }

        [HttpDelete("remove/{name}")]
        public IActionResult RemoveObserver(string name)
        {
            if (!_observers.ContainsKey(name))
            {
                return NotFound(new
                {
                    Message = $"Observer with name '{name}' not found."
                });
            }

            var observer = _observers[name];
            _subject.Detach(observer);
            _observers.Remove(name);

            return Ok(new
            {
                ObserverName = name,
                Observers = GetObserversInfo(),
                Message = $"Observer '{name}' removed."
            });
        }

        [HttpPost("notify")]
        public IActionResult NotifyObservers()
        {
            // Execute some business logic that changes the subject's state
            _subject.SomeBusinessLogic();

            return Ok(new
            {
                SubjectState = _subject.State,
                Observers = GetObserversInfo(),
                Message = "Subject state changed and observers notified."
            });
        }

        private List<object> GetObserversInfo()
        {
            var observersInfo = new List<object>();

            foreach (var entry in _observers)
            {
                if (entry.Value is ConcreteObserverA observerA)
                {
                    observersInfo.Add(new
                    {
                        Name = entry.Key,
                        Type = "A",
                        LastState = observerA.LastState,
                        LastReaction = observerA.LastReaction
                    });
                }
                else if (entry.Value is ConcreteObserverB observerB)
                {
                    observersInfo.Add(new
                    {
                        Name = entry.Key,
                        Type = "B",
                        LastState = observerB.LastState,
                        LastReaction = observerB.LastReaction
                    });
                }
            }

            return observersInfo;
        }
    }
}
