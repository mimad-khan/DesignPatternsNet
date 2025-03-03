using DesignPatternsNet.Creational.Singleton;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SingletonController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllSettings()
        {
            var configManager = AppConfigurationManager.Instance;
            return Ok(new
            {
                Settings = configManager.GetAllSettings(),
                Message = "Retrieved all settings from the singleton configuration manager."
            });
        }

        [HttpGet("{key}")]
        public IActionResult GetSetting(string key)
        {
            var configManager = AppConfigurationManager.Instance;
            var value = configManager.GetSetting(key);
            
            if (string.IsNullOrEmpty(value))
            {
                return NotFound($"Setting with key '{key}' not found");
            }
            
            return Ok(new
            {
                Key = key,
                Value = value,
                Message = $"Retrieved setting '{key}' from the singleton configuration manager."
            });
        }

        [HttpPost]
        public IActionResult SetSetting([FromBody] SettingRequest request)
        {
            var configManager = AppConfigurationManager.Instance;
            configManager.SetSetting(request.Key, request.Value);
            
            return Ok(new
            {
                Key = request.Key,
                Value = request.Value,
                Message = $"Setting '{request.Key}' updated successfully in the singleton configuration manager."
            });
        }

        [HttpPost("reset")]
        public IActionResult ResetToDefaults()
        {
            var configManager = AppConfigurationManager.Instance;
            configManager.ResetToDefaults();
            
            return Ok(new
            {
                Settings = configManager.GetAllSettings(),
                Message = "Settings reset to defaults in the singleton configuration manager."
            });
        }
    }

    public class SettingRequest
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
