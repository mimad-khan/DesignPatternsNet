using DesignPatternsNet.Common.Documents;
using DesignPatternsNet.Creational.FactoryMethod.Factories;
using Xunit;

namespace DesignPatternsNet.Tests.Creational
{
    public class FactoryMethodTests
    {
        [Fact]
        public void PdfDocumentFactory_CreateDocument_ReturnsPdfDocument()
        {
            // Arrange
            var factory = new PdfDocumentFactory();
            
            // Act
            var document = factory.CreateDocument();
            
            // Assert
            Assert.NotNull(document);
            Assert.Equal("PDF Document", document.Name);
            Assert.Equal(".pdf", document.FileType);
        }
        
        [Fact]
        public void WordDocumentFactory_CreateDocument_ReturnsWordDocument()
        {
            // Arrange
            var factory = new WordDocumentFactory();
            
            // Act
            var document = factory.CreateDocument();
            
            // Assert
            Assert.NotNull(document);
            Assert.Equal("Word Document", document.Name);
            Assert.Equal(".docx", document.FileType);
        }
        
        [Fact]
        public void ExcelDocumentFactory_CreateDocument_ReturnsExcelDocument()
        {
            // Arrange
            var factory = new ExcelDocumentFactory();
            
            // Act
            var document = factory.CreateDocument();
            
            // Assert
            Assert.NotNull(document);
            Assert.Equal("Excel Document", document.Name);
            Assert.Equal(".xlsx", document.FileType);
        }
    }
}
