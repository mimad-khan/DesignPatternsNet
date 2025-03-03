using DesignPatternsNet.Common.Documents;
using DesignPatternsNet.Creational.FactoryMethod.Documents;

namespace DesignPatternsNet.Creational.FactoryMethod.Factories
{
    /// <summary>
    /// Factory for creating Excel documents
    /// </summary>
    public class ExcelDocumentFactory : IDocumentFactory
    {
        public IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }
}
