using ProductsAPI.Data;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories;

public class ProductRepository:IProductRepository
{
    private readonly AppDbContext _context;
    
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

   public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.ID == id);
    }

    public void Add(Product product)
    {
        _context.Add(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Delete(Product product)
    {
        _context.Remove(product);
    }

   public bool SaveChanges()
   {
       return _context.SaveChanges()>0;
   }
    
    
}