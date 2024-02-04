using Microsoft.AspNetCore.Mvc;
using NewDependencyInjection.Abstractions;
using NewDependencyInjection.Repositories;

namespace NewDependencyInjection.Controllers;

public class ProductsController : ApiController
{
    public ProductsController(IProductService productService) : base(productService)
    {
    }

    [HttpGet]
    public IActionResult Get2()
    {
        //IProductService _productService =  new EfProductService(); 
        _productService.Save();


        return NoContent();
    }
}
