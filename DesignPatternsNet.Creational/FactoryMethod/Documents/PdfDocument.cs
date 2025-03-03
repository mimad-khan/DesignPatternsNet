using DesignPatternsNet.Common.Documents;
using System;

namespace DesignPatternsNet.Creational.FactoryMethod.Documents
{
    /// <summary>
    /// Concrete implementation of PDF document
    /// </summary>
    public class PdfDocument : IDocument
    {
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string FileType => "PDF";

        public void Open()
        {
            Console.WriteLine($"Opening PDF document: {Name}");
        }

        public void Save()
        {
            Console.WriteLine($"Saving PDF document: {Name}");
        }
    }
}
