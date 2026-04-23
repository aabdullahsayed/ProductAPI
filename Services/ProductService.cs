using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Repositories;
using ProductsAPI.Services;

public class ProductService:IProductService
{
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }

    public Product GetProductById(int id)
    {

        return _repository.GetById(id);
    }

    public Product AddProduct(Product product)
    {
        _repository.Add(product);
        _repository.SaveChanges();
        
        return product;
    }

    public Product UpdateProduct(int id, Product update)
    {
        var res = _repository.GetById(id);

        res.Name = update.Name; 
        res.Price = update.Price;
        
        _repository.SaveChanges();
        
        return res;
    }

    public bool DeleteProduct(int id)
    {
        var res = _repository.GetById(id);

        _repository.Delete(res);
        _repository.SaveChanges();
        return true;
    }
    
}