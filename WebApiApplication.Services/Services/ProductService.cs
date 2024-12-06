using Microsoft.EntityFrameworkCore;
using WebApiApplication.Data;
using WebApiApplication.Interfaces;
using WebApiApplication.Models;

namespace WebApiApplication.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddNewProduct(Product newProduct)
        {
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return newProduct;
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var product = _dbContext.Products.Find(id);
            return product;
        }

        public Product UpdateProduct(int id, Product updatedProduct)
        {
            _dbContext.Entry(updatedProduct).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return updatedProduct; 
        }
        public void DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
