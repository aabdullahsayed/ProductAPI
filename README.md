`This code represents a classic ASP.NET Core API controller before the introduction of a Service Layer. In this architecture, the controller is acting as a "fat controller," meaning it takes on more responsibilities than it ideally should.`
```c#
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

```

By refactoring this code to include a Service Layer, we will extract all the _context logic into a dedicated service. The controller will then become much "thinner" it will simply receive the HTTP request, hand the data off to the Service Layer to do the heavy lifting, and return the appropriate HTTP status code.


