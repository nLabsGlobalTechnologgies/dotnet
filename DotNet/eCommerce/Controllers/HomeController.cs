using eCommerce.Context;
using eCommerce.DTOs;
using eCommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers;

public class HomeController : ApiController
{
    public HomeController(ApplicationDbContext context) : base(context)
    {
    }

    [HttpPost]
    public IActionResult Create(AddCategoryDto request)
    {
        Category category = new()
        {
            Name = request.Name,
            Icon = request.Icon,
            Description = request.Description
        };
        var result = _context.Add(category);

        return StatusCode(200, result);
    }

    [HttpPost]
    public IActionResult Update(UpdateCategoryDto request)
    {
        var category = _context.Category!.Find(request.Id);
        if (category is null)
        {
            throw new ArgumentException("Kategori bulunamadı!");
        }
        category.Name = request.Name;
        category.Icon = request.Icon;
        category.Description = request.Description;

        _context.Update(category);

        return NoContent();
    }

    [HttpPost]
    public IActionResult GetProducts()
    {
        // Veritabanından ürünleri çek, aynı zamanda ilişkili kategori bilgilerini de getir.
        var products = _context.Products.Include(p => p.Category).ToList();
    
        // Her bir ürünü, yalnızca ilgili özellikleri içerecek şekilde bir anonim nesne içinde düzenle.
        var productsWithCategory = products.Select(p => new
        {
            Name = p.Name,
            Title = p.Title,
            Quantity = p.Quantity,
            Discount = p.Discount,
            Price = p.Price,
    
            // Kategori bilgilerini doğru bir şekilde oluşturun ve değerleri atayın.
            Category = new
            {
                CategoryId = p.Category?.Id,
                CategoryName = p.Category?.Name,
                CategoryIcon = p.Category?.Icon,
                CategoryDescription = p.Category?.Description
            }
        });
    
        // İşlemlerin tamamlandığına dair bir işareti döndür.
        return Ok(productsWithCategory);
    }

}
