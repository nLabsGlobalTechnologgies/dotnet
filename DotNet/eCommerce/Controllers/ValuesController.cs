using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
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

        return NoContent();
    }
}
