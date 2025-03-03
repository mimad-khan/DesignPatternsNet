using DesignPatternsNet.Common.UI;
using System;

namespace DesignPatternsNet.Creational.AbstractFactory.Light
{
    /// <summary>
    /// Light-themed textbox implementation
    /// </summary>
    public class LightTextBox : ITextBox
    {
        public string BorderColor => "#CCCCCC";
        public string BackgroundColor => "#FFFFFF";
        public string Text { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;

        public void OnTextChanged(string newText)
        {
            Console.WriteLine($"Light textbox text changed to: {newText}");
            Text = newText;
        }

        public void Render()
        {
            Console.WriteLine($"Rendering light textbox with placeholder '{Placeholder}', border color {BorderColor}, and background color {BackgroundColor}");
        }
    }
}
