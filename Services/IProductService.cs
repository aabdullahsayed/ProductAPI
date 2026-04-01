using ProductsAPI.Models;

namespace ProductsAPI.Services;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    Product AddProduct(Product product);
    Product UpdateProduct(int id, Product update);
    bool DeleteProduct(int id);   
}