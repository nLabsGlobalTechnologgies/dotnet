using First.Context;
using First.DTOs;
using First.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace First.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class TodosController(AppDbContext context) : ControllerBase
{
    [HttpPost]  //Create  
    public IActionResult Add(AddTodoDto request)
    {
        Todo todo = new()
        {
            Work = request.Work.Trim(), //    asdasd  => asdasd
            StartDate = request.StartDate,
            CreatedDate = DateTime.Now
        };

        //context.Todos.Add(todo);
        context.Add(todo);

        context.SaveChanges();

        return Ok(new { todo.Id });
    }


    [HttpGet] //Read
    public IActionResult GetAll()
    {
        IEnumerable<Todo> todos = context.Todos.OrderByDescending(p => p.CreatedDate).ToList();
        return Ok(todos);
    }

    [HttpGet] //Read
    public IActionResult GetById(int id)
    {
        Todo? todo = context.Todos.Find(id);

        //string work = todo!.Work;

        if (todo is null)
        {
            return BadRequest(new { Message = "Todo kaydı bulunamadı!" });
        }

        return Ok(todo);
    }

    [HttpGet] //Read
    public IActionResult GetByWork(string work)
    {
        IEnumerable<Todo>? todos = context.Todos?.Where(p => p.Work.ToLower().Contains(work.ToLower())).ToList();

        return Ok(todos);
    }

    [HttpPost] //Read
    public IActionResult GetByExpression(Expression<Func<Todo, bool>> expression)
    {
        IEnumerable<Todo>? todos = context.Todos?.Where(expression).ToList();

        return Ok(todos);
    }

    [HttpPost] // Update
    public IActionResult Update(UpdateTodoDto request)
    {
        Todo? todo = context.Todos?.Find(request.Id);

        if (todo is null)
        {
            return BadRequest(new { Message = "Todo kaydı bulunamadı" });
        }

        todo.Work = request.Work;
        todo.StartDate = request.StartDate;

        //context.Update(todo); //tracking mekanizması olduğundan buna gerek yok
        context.SaveChanges();

        return Ok(new { todo.Id });
    }

    [HttpGet] // Update
    public IActionResult ChangeCompletedStatus(int id)
    {
        Todo? todo = context.Todos?.Find(id);

        if (todo is null)
        {
            return BadRequest(new { Message = "Todo kaydı bulunamadı" });
        }

        todo.IsCompleted = !todo.IsCompleted;
        todo.StartDate = todo.StartDate == "" ? null : DateTime.Now.ToString();

        context.SaveChanges();

        return NoContent();
    }

    [HttpGet] //Remove
    public IActionResult RemoveById(int id)
    {
        Todo? todo = context.Todos?.Find(id);

        if (todo is null)
        {
            return BadRequest(new { Message = "Todo kaydı bulunamadı" });
        }

        context.Remove(todo);
        context.SaveChanges();

        return NoContent();
    }
}
