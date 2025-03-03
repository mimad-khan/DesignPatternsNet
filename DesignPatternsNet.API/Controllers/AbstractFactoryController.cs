using DesignPatternsNet.Common.UI;
using DesignPatternsNet.Creational.AbstractFactory;
using DesignPatternsNet.Creational.AbstractFactory.Dark;
using DesignPatternsNet.Creational.AbstractFactory.Light;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbstractFactoryController : ControllerBase
    {
        [HttpGet("create/{theme}")]
        public IActionResult CreateUIComponents(string theme)
        {
            IThemeFactory factory;

            switch (theme.ToLower())
            {
                case "light":
                    factory = new LightThemeFactory();
                    break;
                case "dark":
                    factory = new DarkThemeFactory();
                    break;
                default:
                    return BadRequest($"Unsupported theme: {theme}");
            }

            // Create button
            IButton button = factory.CreateButton();
            button.Text = "Submit";
            button.Position = "100,100";
            
            // Create textbox
            ITextBox textBox = factory.CreateTextBox();
            textBox.Placeholder = "Enter your name";

            // In a real application, we would render these components
            button.Render();
            textBox.Render();

            return Ok(new
            {
                Theme = factory.ThemeName,
                Button = new
                {
                    Text = button.Text,
                    Color = button.Color,
                    Position = button.Position
                },
                TextBox = new
                {
                    Placeholder = textBox.Placeholder,
                    BorderColor = textBox.BorderColor,
                    BackgroundColor = textBox.BackgroundColor
                },
                Message = $"UI components created successfully using the {factory.ThemeName} theme factory."
            });
        }
    }
}
