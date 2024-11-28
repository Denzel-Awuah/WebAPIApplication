using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Data;
using WebApiApplication.Interfaces;
using WebApiApplication.Models;
using WebApiApplication.Models.DTOs;

namespace WebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _productService.GetProductById(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddNewProduct([FromBody] AddProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Category = productDto.Category,
                Description = productDto.Description,
            };

            var newProduct = _productService.AddNewProduct(product);
            return Ok(newProduct);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProductById([FromRoute] int id, [FromBody] Product updatedProduct)
        {
            if(id != updatedProduct.Id)
            {
                return BadRequest();
            }

            _productService.UpdateProduct(id, updatedProduct);

            return Ok(updatedProduct);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(product);
            return Ok(product);
        }

    }
}
