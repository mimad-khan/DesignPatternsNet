namespace DesignPatternsNet.Common.Documents
{
    /// <summary>
    /// Interface for document types
    /// </summary>
    public interface IDocument
    {
        string Name { get; set; }
        string Content { get; set; }
        string FileType { get; }
        void Open();
        void Save();
    }
}
