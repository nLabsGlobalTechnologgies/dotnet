using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Interfaces;

namespace RepositoryDesignPattern.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class OrdersController(IOrderRepository orderRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await orderRepository.GetAllAsync();

        return Ok(orders);
    }
}
