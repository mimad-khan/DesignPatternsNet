using DesignPatternsNet.Common.Documents;

namespace DesignPatternsNet.Creational.FactoryMethod
{
    /// <summary>
    /// Factory interface for creating document instances
    /// </summary>
    public interface IDocumentFactory
    {
        IDocument CreateDocument();
    }
}
