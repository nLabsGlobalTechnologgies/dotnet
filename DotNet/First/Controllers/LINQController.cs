using First.Context;
using First.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class LINQController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        AppDbContext context = new();
        List<Todo> todos = context.Todos.ToList();
        context.Set<Todo>().ToList();


        List<string> names = new();
        names.Add("Cuma");
        names.Remove("Cuma");
        List<string> newNames = names.Where(p => p == "Cuma").ToList();
        string? newName = names.FirstOrDefault(p => p == "Cuma");
        string? newName2 = names.SingleOrDefault(p => p == "Cuma");
        string? newName3 = names.Where(p => p == "Cuma").FirstOrDefault();


        List<Example> examples = new();
        var newExample = examples.Select(s => new NewExample()
        {
            Name = string.Join(" ", s.FirstName, s.LastName),
            Age = s.Age,
            City = "Elazıg"
        }).ToList();


        int result = examples.Sum(s => s.Age);

        int count = examples.Count();

        AppDbContext context2 = new();
        todos = (List<Todo>)context.Todos.AsQueryable();

        todos.Where(p => p.IsCompleted);

        return Ok();
    }
}

//LINQ Language Integrated Query

public class Example
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
}

public class NewExample
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string City { get; set; } = string.Empty;
}
