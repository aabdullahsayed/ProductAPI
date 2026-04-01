using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Services;

public class ProductService:IProductService
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products;
    }

    public Product GetProductById(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ID == id);

        return product;
    }

    public Product AddProduct(Product product)
    {
        _context.Add(product);
        _context.SaveChanges();

        return product;
    }

    public Product UpdateProduct(int id, Product update)
    {
        var res = _context.Products.FirstOrDefault(p => p.ID == id);

        res.Name = update.Name; 
        res.Price = update.Price;
        _context.SaveChanges();
        return res;
    }

    public bool DeleteProduct(int id)
    {
        var delete = _context.Products.FirstOrDefault(p => p.ID == id);

        _context.Products.Remove(delete);
        _context.SaveChanges();

        return true;
    }
    
}