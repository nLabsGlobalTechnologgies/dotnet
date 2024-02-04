using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Interfaces;
using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult Add(string name)
    {
        User user = new()
        {
            Name = name,
        };

        userRepository.Add(user);

        return Ok(user.Id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await userRepository.GetAllAsync();

        return Ok(users);
    }
}
