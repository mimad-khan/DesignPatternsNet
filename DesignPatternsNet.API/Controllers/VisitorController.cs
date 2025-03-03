using DesignPatternsNet.Behavioral.Visitor;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        private static readonly List<IComponent> _components = new List<IComponent>
        {
            new ConcreteComponentA(),
            new ConcreteComponentB()
        };

        private static readonly List<IVisitor> _visitors = new List<IVisitor>
        {
            new ConcreteVisitor1(),
            new ConcreteVisitor2()
        };

        [HttpGet("components")]
        public IActionResult GetComponents()
        {
            var componentsList = new List<string>();
            foreach (var component in _components)
            {
                componentsList.Add(component.GetName());
            }

            return Ok(new
            {
                Components = componentsList,
                Message = "Available components retrieved."
            });
        }

        [HttpGet("visitors")]
        public IActionResult GetVisitors()
        {
            var visitorsList = new List<string>();
            foreach (var visitor in _visitors)
            {
                visitorsList.Add(visitor.GetName());
            }

            return Ok(new
            {
                Visitors = visitorsList,
                Message = "Available visitors retrieved."
            });
        }

        [HttpGet("visit/{visitorIndex}/{componentIndex}")]
        public IActionResult VisitComponent(int visitorIndex, int componentIndex)
        {
            if (visitorIndex < 0 || visitorIndex >= _visitors.Count)
            {
                return BadRequest(new
                {
                    Message = $"Invalid visitor index: {visitorIndex}. Available indices: 0-{_visitors.Count - 1}."
                });
            }

            if (componentIndex < 0 || componentIndex >= _components.Count)
            {
                return BadRequest(new
                {
                    Message = $"Invalid component index: {componentIndex}. Available indices: 0-{_components.Count - 1}."
                });
            }

            var visitor = _visitors[visitorIndex];
            var component = _components[componentIndex];
            
            var result = component.Accept(visitor);

            return Ok(new
            {
                Visitor = visitor.GetName(),
                Component = component.GetName(),
                Result = result,
                Message = $"Component {component.GetName()} visited by {visitor.GetName()}."
            });
        }

        [HttpGet("visit-all")]
        public IActionResult VisitAllComponents()
        {
            var results = new List<object>();

            foreach (var visitor in _visitors)
            {
                var visitorResults = new List<object>();
                
                foreach (var component in _components)
                {
                    var result = component.Accept(visitor);
                    
                    visitorResults.Add(new
                    {
                        Component = component.GetName(),
                        Result = result
                    });
                }
                
                results.Add(new
                {
                    Visitor = visitor.GetName(),
                    Results = visitorResults
                });
            }

            return Ok(new
            {
                Results = results,
                Message = "All components visited by all visitors."
            });
        }
    }
}
