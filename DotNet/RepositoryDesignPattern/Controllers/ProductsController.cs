using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Interfaces;
using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController(IProductRepository productRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult Add(string name)
    {

        Product product = new()
        {
            Name = name,
        };

        productRepository.Add(product);

        return Ok(product.Id);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await productRepository.GetAllAsync();
        return Ok(result);
    }
}
