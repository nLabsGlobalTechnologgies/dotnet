using eCommerce.Context;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;
[Route("api/[controller]/[action")]
[ApiController]
public class ApiController : ControllerBase   
{
    public ApplicationDbContext _context;

    public ApiController(ApplicationDbContext context)
    {
        _context = context;
    }
}
