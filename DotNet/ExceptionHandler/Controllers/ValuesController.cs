using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandler.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        //1
        //try
        //{

        //}
        //catch (Exception)
        //{
        //    //500 200 204 //422 429 //401            
        //    throw;
        //}

        //int x = 0;
        //int y = 0;
        //int z = x / y;

        // throw new ArgumentException("Argumen hatası");
        // throw new Exception("Argumen hatası");
        //  throw new UnauthorizedAccessException("Argumen hatası");
        //throw new MyException("Özelleştirilmiş exception hatası");
        return Ok();
    }
}
