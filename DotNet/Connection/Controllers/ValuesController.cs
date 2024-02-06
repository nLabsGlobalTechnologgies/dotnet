using Connection.Context;
using Connection.Models;
using Microsoft.AspNetCore.Mvc;

namespace Connection.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController(AppDbContext context) : ControllerBase
{
    [HttpPost]
    public IActionResult Create(string name)
    {
        Personel employee = new()
        {
            Name = name
        };

        context.Add(employee);
        context.SaveChanges();

        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = context.Employees?.ToList();

        return Ok(employees);
    }
}
