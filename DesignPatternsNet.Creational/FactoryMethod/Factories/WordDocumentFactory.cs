using DesignPatternsNet.Common.Documents;
using DesignPatternsNet.Creational.FactoryMethod.Documents;

namespace DesignPatternsNet.Creational.FactoryMethod.Factories
{
    /// <summary>
    /// Factory for creating Word documents
    /// </summary>
    public class WordDocumentFactory : IDocumentFactory
    {
        public IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }
}
