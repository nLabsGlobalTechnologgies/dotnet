using Microsoft.AspNetCore.Mvc;
using NewDependencyInjection.Repositories;

namespace NewDependencyInjection.Abstractions;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    public readonly IProductService _productService;
    public ApiController(IProductService productService)
    {
        _productService = productService;
    }
}
