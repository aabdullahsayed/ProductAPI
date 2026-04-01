using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController:ControllerBase
{
    

    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }
    
    
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_context.Products);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {

        _context.Products.Add(product);
        _context.SaveChanges();
        return Ok(_context.Products);
    }


    [HttpGet("{id}")]
        public IActionResult GetProductbyId(int id)
        {
            
            var product = _context.Products.FirstOrDefault(p => p.ID == id);
            return Ok(product);
        }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(Product update, int id)
    {
        var res = _context.Products.FirstOrDefault(p => p.ID == id);

        res.Name = update.Name; 
        res.Price = update.Price;
        _context.SaveChanges();

        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var delete = _context.Products.FirstOrDefault(p => p.ID == id);

        _context.Products.Remove(delete);
        _context.SaveChanges();

        return Ok(_context.Products);
    }
    
}