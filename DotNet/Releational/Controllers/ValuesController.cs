using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Releational.Context;
using Releational.DTOs;
using Releational.Models;

namespace Releational.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ValuesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Add(AddProductDto request)
    {
        Product? product = _context.Products.FirstOrDefault(p => p.Name == request.ProductName);

        if (product is not null)
        {
            return BadRequest(new { Message = "Bu ürün adı daha önce kullanılmış!" });
        }

        product = new()
        {
            Id = Guid.NewGuid(),
            Name = request.ProductName,
        };

        AdditionalProduct additionalProduct = new()
        {
            Description = request.ProductDescription,
            Price = request.ProductPrice
        };

        product.AdditionalProduct = additionalProduct;


        Category? category = _context.Categories.FirstOrDefault(p => p.Name == request.CategoryName);

        if (category is null)
        {
            category = new()
            {
                Id = Guid.NewGuid(),
                Name = request.CategoryName,
            };

            product.Category = category;
        }
        else
        {
            product.CategoryId = category.Id;
        }

        _context.Add(product);
        _context.SaveChanges();

        return Ok(new { Id = product.Id });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Product> products1 =
            _context.Products
            .Include(p => p.Category)
            .ToList();

        List<Product> products2 = (from p in _context.Products
                                  join ad in _context.AdditionalProducts on p.Id equals ad.ProductId
                                  join c in _context.Categories on p.CategoryId equals c.Id
                                  select new Product()
                                  {
                                      Id = p.Id,
                                      AdditionalProduct = ad,
                                      CategoryId = p.CategoryId,
                                      Category = c,
                                      Name = p.Name
                                  }).ToList();

        return Ok(products1);
    }
}
