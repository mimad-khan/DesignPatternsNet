using DesignPatternsNet.Common.UI;

namespace DesignPatternsNet.Creational.AbstractFactory
{
    /// <summary>
    /// Abstract factory interface for creating UI components
    /// </summary>
    public interface IThemeFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
        string ThemeName { get; }
    }
}
