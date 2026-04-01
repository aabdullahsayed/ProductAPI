using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController:ControllerBase
{
    
    private readonly IProductService _service;
    public ProductsController(IProductService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_service.GetAllProducts());
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        
        var createdProduct = _service.AddProduct(product);

        return Ok(createdProduct);
    }


    [HttpGet("{id}")]
        public IActionResult GetProductbyId(int id)
        {

            var product = _service.GetProductById(id);
            
            return Ok(product);
        }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(Product update, int id)
    {
        var res = _service.UpdateProduct(id, update);

        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var delete = _service.DeleteProduct(id);
        return Ok(delete);
    }
    
}