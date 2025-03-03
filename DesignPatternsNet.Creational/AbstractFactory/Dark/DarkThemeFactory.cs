using DesignPatternsNet.Common.UI;

namespace DesignPatternsNet.Creational.AbstractFactory.Dark
{
    /// <summary>
    /// Factory for creating dark-themed UI components
    /// </summary>
    public class DarkThemeFactory : IThemeFactory
    {
        public string ThemeName => "Dark";

        public IButton CreateButton()
        {
            return new DarkButton();
        }

        public ITextBox CreateTextBox()
        {
            return new DarkTextBox();
        }
    }
}
