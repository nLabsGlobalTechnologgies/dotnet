using Microsoft.AspNetCore.Mvc;
using NewDependencyInjection.Abstractions;
using NewDependencyInjection.Repositories;

namespace NewDependencyInjection.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ApiController
{
    public ValuesController(IProductService productService) : base(productService)
    {
    }

    [HttpGet]
    public IActionResult Get()
    {
        //IProductService _productService =  new EfProductService(); 
        _productService.Save();


        return NoContent();
    }
}