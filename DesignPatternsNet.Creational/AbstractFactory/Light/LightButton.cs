using DesignPatternsNet.Common.UI;
using System;

namespace DesignPatternsNet.Creational.AbstractFactory.Light
{
    /// <summary>
    /// Light-themed button implementation
    /// </summary>
    public class LightButton : IButton
    {
        public string Color => "#FFFFFF";
        public string Position { get; set; } = "0,0";
        public string Text { get; set; } = string.Empty;

        public void OnClick()
        {
            Console.WriteLine($"Light button '{Text}' clicked");
        }

        public void Render()
        {
            Console.WriteLine($"Rendering light button '{Text}' at position {Position} with color {Color}");
        }
    }
}
