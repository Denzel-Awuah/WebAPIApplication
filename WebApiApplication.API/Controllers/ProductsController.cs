using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Data;
using WebApiApplication.Interfaces;
using WebApiApplication.Models;
using WebApiApplication.Models.DTOs;

namespace WebApiApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //Services
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //GET: api/Products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        //GET: api/Products/{id}
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

        //POST: api/Products
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

        //PUT: api/Products/{id}
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

        //DELETE: api/Products/{id}
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
