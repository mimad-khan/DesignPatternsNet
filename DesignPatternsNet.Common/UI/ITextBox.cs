namespace DesignPatternsNet.Common.UI
{
    /// <summary>
    /// Interface for textbox UI components
    /// </summary>
    public interface ITextBox
    {
        string BorderColor { get; }
        string BackgroundColor { get; }
        string Text { get; set; }
        string Placeholder { get; set; }
        void Render();
        void OnTextChanged(string newText);
    }
}
