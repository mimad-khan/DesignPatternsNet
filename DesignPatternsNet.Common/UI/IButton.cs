namespace DesignPatternsNet.Common.UI
{
    /// <summary>
    /// Interface for button UI components
    /// </summary>
    public interface IButton
    {
        string Color { get; }
        string Position { get; set; }
        string Text { get; set; }
        void Render();
        void OnClick();
    }
}
