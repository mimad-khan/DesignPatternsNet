using DesignPatternsNet.Common.Computer;
using DesignPatternsNet.Creational.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuilderController : ControllerBase
    {
        [HttpGet("build/{computerType}")]
        public IActionResult BuildComputer(string computerType)
        {
            ComputerDirector director = new ComputerDirector();
            Computer computer;

            switch (computerType.ToLower())
            {
                case "gaming":
                    computer = director.BuildComputer(new GamingComputerBuilder());
                    break;
                case "workstation":
                    computer = director.BuildComputer(new WorkstationBuilder());
                    break;
                default:
                    return BadRequest($"Unsupported computer type: {computerType}");
            }

            // Convert the computer to a more JSON-friendly format
            var computerDetails = new
            {
                Name = computer.Name,
                CPU = computer.CPU != null ? $"{computer.CPU.Brand} {computer.CPU.Model}" : null,
                GPU = computer.GPU != null ? $"{computer.GPU.Brand} {computer.GPU.Model}" : null,
                RAM = computer.RAM != null ? $"{computer.RAM.CapacityGB}GB {computer.RAM.Type}" : null,
                Storage = computer.Storage != null ? $"{computer.Storage.CapacityGB}GB {computer.Storage.Type}" : null,
                Motherboard = computer.Motherboard != null ? $"{computer.Motherboard.Brand} {computer.Motherboard.Model}" : null,
                PowerSupply = computer.PowerSupply != null ? $"{computer.PowerSupply.Brand} {computer.PowerSupply.WattageRating}W" : null,
                HasWiFi = computer.HasWiFi,
                HasBluetooth = computer.HasBluetooth,
                CaseType = computer.CaseType
            };

            return Ok(new
            {
                ComputerType = computerType,
                Computer = computerDetails,
                Message = $"{computerType} computer built successfully using the Builder pattern."
            });
        }
    }
}
