using DesignPatternsNet.Common.Documents;
using DesignPatternsNet.Creational.FactoryMethod.Documents;

namespace DesignPatternsNet.Creational.FactoryMethod.Factories
{
    /// <summary>
    /// Factory for creating PDF documents
    /// </summary>
    public class PdfDocumentFactory : IDocumentFactory
    {
        public IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }
}
