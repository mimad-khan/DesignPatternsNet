using DesignPatternsNet.Behavioral.TemplateMethod;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateMethodController : ControllerBase
    {
        [HttpGet("class1")]
        public IActionResult ExecuteClass1()
        {
            var algorithm = new ConcreteClass1();
            var steps = algorithm.TemplateMethod();

            return Ok(new
            {
                AlgorithmClass = "ConcreteClass1",
                ExecutionSteps = steps,
                Message = "ConcreteClass1 template method executed successfully."
            });
        }

        [HttpGet("class2")]
        public IActionResult ExecuteClass2()
        {
            var algorithm = new ConcreteClass2();
            var steps = algorithm.TemplateMethod();

            return Ok(new
            {
                AlgorithmClass = "ConcreteClass2",
                ExecutionSteps = steps,
                Message = "ConcreteClass2 template method executed successfully."
            });
        }

        [HttpGet("compare")]
        public IActionResult CompareImplementations()
        {
            var class1 = new ConcreteClass1();
            var steps1 = class1.TemplateMethod();

            var class2 = new ConcreteClass2();
            var steps2 = class2.TemplateMethod();

            var comparison = new List<object>();
            for (int i = 0; i < steps1.Count; i++)
            {
                comparison.Add(new
                {
                    StepNumber = i + 1,
                    ConcreteClass1 = steps1[i],
                    ConcreteClass2 = steps2[i],
                    Different = steps1[i] != steps2[i]
                });
            }

            return Ok(new
            {
                Comparison = comparison,
                Message = "Template method implementations compared."
            });
        }
    }
}
