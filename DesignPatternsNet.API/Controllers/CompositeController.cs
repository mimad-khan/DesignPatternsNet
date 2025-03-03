using DesignPatternsNet.Structural.Composite;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompositeController : ControllerBase
    {
        [HttpGet]
        public IActionResult DemonstrateComposite()
        {
            // Create a product catalog structure
            var catalog = new Composite("Product Catalog");

            // Create categories
            var electronics = new Composite("Electronics");
            var clothing = new Composite("Clothing");
            
            // Add categories to catalog
            catalog.Add(electronics);
            catalog.Add(clothing);

            // Create subcategories for electronics
            var smartphones = new Composite("Smartphones");
            var laptops = new Composite("Laptops");
            
            // Add subcategories to electronics
            electronics.Add(smartphones);
            electronics.Add(laptops);

            // Add products to smartphones
            smartphones.Add(new Leaf("iPhone 13", 999));
            smartphones.Add(new Leaf("Samsung Galaxy S21", 899));
            
            // Add products to laptops
            laptops.Add(new Leaf("MacBook Pro", 1999));
            laptops.Add(new Leaf("Dell XPS 15", 1799));

            // Add products to clothing
            clothing.Add(new Leaf("T-Shirt", 29));
            clothing.Add(new Leaf("Jeans", 59));

            // Calculate the total price of the catalog
            var totalPrice = catalog.GetPrice();

            // Build a tree representation of the catalog
            var catalogTree = BuildComponentTree(catalog);

            return Ok(new
            {
                Catalog = catalogTree,
                TotalPrice = totalPrice,
                Message = "Composite pattern successfully demonstrated."
            });
        }

        private object BuildComponentTree(Component component)
        {
            if (component.IsComposite())
            {
                var composite = (Composite)component;
                var children = composite.GetChildren().Select(child => BuildComponentTree(child)).ToList();
                
                return new
                {
                    Name = component.Name,
                    Price = component.GetPrice(),
                    IsComposite = true,
                    Children = children
                };
            }
            else
            {
                return new
                {
                    Name = component.Name,
                    Price = component.GetPrice(),
                    IsComposite = false,
                    Children = new List<object>()
                };
            }
        }
    }
}
