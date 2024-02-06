using eCommerce.Context;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;
[Route("api/[controller]/[action")]
[ApiController]
public class ApiController(ApplicationDbContext context) : ControllerBase   
{
}
