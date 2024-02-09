using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Entities.DTOs;

namespace NTierArchitecture.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StudentsController(StudentService studentService) : ControllerBase
{
    [HttpPost]
    public IActionResult Create(CreateStudentDto request)
    {
        var message = studentService.Create(request);
        return Ok(new { Message = message });
    }
}
