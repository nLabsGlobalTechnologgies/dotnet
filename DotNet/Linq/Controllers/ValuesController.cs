using eCommerce.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linq.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        List<string> names = new();

        //Linq Kodları

        //Ekleme
        names.Add("");
        //liste ekleme
        names.AddRange(names);
        //güncelleme
        context.Update(names);

        return NoContent();
    }
}
