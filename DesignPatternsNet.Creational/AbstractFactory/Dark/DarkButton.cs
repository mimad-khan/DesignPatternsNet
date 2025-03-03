using DesignPatternsNet.Common.UI;
using System;

namespace DesignPatternsNet.Creational.AbstractFactory.Dark
{
    /// <summary>
    /// Dark-themed button implementation
    /// </summary>
    public class DarkButton : IButton
    {
        public string Color => "#333333";
        public string Position { get; set; } = "0,0";
        public string Text { get; set; } = string.Empty;

        public void OnClick()
        {
            Console.WriteLine($"Dark button '{Text}' clicked");
        }

        public void Render()
        {
            Console.WriteLine($"Rendering dark button '{Text}' at position {Position} with color {Color}");
        }
    }
}
