using DesignPatternsNet.Common.UI;

namespace DesignPatternsNet.Creational.AbstractFactory.Light
{
    /// <summary>
    /// Factory for creating light-themed UI components
    /// </summary>
    public class LightThemeFactory : IThemeFactory
    {
        public string ThemeName => "Light";

        public IButton CreateButton()
        {
            return new LightButton();
        }

        public ITextBox CreateTextBox()
        {
            return new LightTextBox();
        }
    }
}
