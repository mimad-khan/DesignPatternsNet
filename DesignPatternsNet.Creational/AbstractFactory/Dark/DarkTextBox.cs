using DesignPatternsNet.Common.UI;
using System;

namespace DesignPatternsNet.Creational.AbstractFactory.Dark
{
    /// <summary>
    /// Dark-themed textbox implementation
    /// </summary>
    public class DarkTextBox : ITextBox
    {
        public string BorderColor => "#555555";
        public string BackgroundColor => "#222222";
        public string Text { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;

        public void OnTextChanged(string newText)
        {
            Console.WriteLine($"Dark textbox text changed to: {newText}");
            Text = newText;
        }

        public void Render()
        {
            Console.WriteLine($"Rendering dark textbox with placeholder '{Placeholder}', border color {BorderColor}, and background color {BackgroundColor}");
        }
    }
}
