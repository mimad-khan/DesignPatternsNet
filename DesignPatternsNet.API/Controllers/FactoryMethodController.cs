using DesignPatternsNet.Common.Documents;
using DesignPatternsNet.Creational.FactoryMethod;
using DesignPatternsNet.Creational.FactoryMethod.Factories;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactoryMethodController : ControllerBase
    {
        [HttpGet("create/{documentType}")]
        public IActionResult CreateDocument(string documentType)
        {
            IDocumentFactory factory;

            switch (documentType.ToLower())
            {
                case "pdf":
                    factory = new PdfDocumentFactory();
                    break;
                case "word":
                    factory = new WordDocumentFactory();
                    break;
                case "excel":
                    factory = new ExcelDocumentFactory();
                    break;
                default:
                    return BadRequest($"Unsupported document type: {documentType}");
            }

            IDocument document = factory.CreateDocument();
            document.Name = $"Sample {document.FileType} Document";
            document.Content = $"This is a sample {document.FileType} document content.";

            // In a real application, we would save the document
            document.Save();

            return Ok(new
            {
                DocumentType = document.FileType,
                Name = document.Name,
                Content = document.Content,
                Message = $"Document created successfully using the {documentType} factory."
            });
        }
    }
}
