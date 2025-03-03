using DesignPatternsNet.Common.Documents;
using System;

namespace DesignPatternsNet.Creational.FactoryMethod.Documents
{
    /// <summary>
    /// Concrete implementation of Excel document
    /// </summary>
    public class ExcelDocument : IDocument
    {
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string FileType => "XLSX";

        public void Open()
        {
            Console.WriteLine($"Opening Excel document: {Name}");
        }

        public void Save()
        {
            Console.WriteLine($"Saving Excel document: {Name}");
        }
    }
}
