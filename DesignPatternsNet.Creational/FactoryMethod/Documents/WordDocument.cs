using DesignPatternsNet.Common.Documents;
using System;

namespace DesignPatternsNet.Creational.FactoryMethod.Documents
{
    /// <summary>
    /// Concrete implementation of Word document
    /// </summary>
    public class WordDocument : IDocument
    {
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string FileType => "DOCX";

        public void Open()
        {
            Console.WriteLine($"Opening Word document: {Name}");
        }

        public void Save()
        {
            Console.WriteLine($"Saving Word document: {Name}");
        }
    }
}
