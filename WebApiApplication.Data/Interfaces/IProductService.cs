using WebApiApplication.Data;
using WebApiApplication.Models;

namespace WebApiApplication.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public Product AddNewProduct(Product newProduct);
        public Product UpdateProduct(int id, Product newProduct);
        public void DeleteProduct(Product product);
    }
}
