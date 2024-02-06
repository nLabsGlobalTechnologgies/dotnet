using eCommerce.Context;
using eCommerce.DTOs;
using eCommerce.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class HomeController : ApiController
{
    public HomeController(ApplicationDbContext context) : base(context)
    {
    }

    [HttpPost]
    public IActionResult Create(ApplicationDbContext context, AddCategoryDto request)
    {
        Category category = new()
        {
            Name = request.Name,
            Icon = request.Icon,
        };
        var result = context.Add(category);

        return StatusCode(200, result);
    }
}
