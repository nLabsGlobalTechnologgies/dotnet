using First.Context;
using First.DTOs;
using First.Models;
using Microsoft.AspNetCore.Mvc;

namespace First.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    /*
        HttpPut | HttpPatch | HttpDelete gibi methodlar genelde kullanılması sıkıntılıdır aşagıdaki örneklerde görülebilir
        bu methodlar her ne kadarda Güncelleme Silme gibi işlemler gibi görülsede görüldügü üzere istedigimiz işlemi yaptırabiliriz
    */
    [HttpDelete] //HttpGet
    public IActionResult Delete(string work, string date)
    {
        Todo todo = new()
        {
            Work = work,
            StartDate = date,
        };

        AppDbContext context = new();
        context.Add(todo);
        context.SaveChanges();
        return Ok(new { Message = "Silme işlemi başarıyla tamamlandı" });
    }

    [HttpPut] //HttpPost
    public IActionResult Update(AddTodoDto request)
    {
        Todo todo = new()
        {
            Work = request.Work,
            StartDate = request.StartDate,
        };

        AppDbContext context = new();
        context.Add(todo);
        context.SaveChanges();
        return Ok(new { Message = "Güncelleme işlemi başarıyla tamamlandı" });
    }
}
