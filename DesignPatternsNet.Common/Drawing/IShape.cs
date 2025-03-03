namespace DesignPatternsNet.Common.Drawing
{
    /// <summary>
    /// Interface for shape objects that can be cloned
    /// </summary>
    public interface IShape
    {
        string Color { get; set; }
        Position Position { get; set; }
        IShape Clone();
        void Draw();
    }
}
