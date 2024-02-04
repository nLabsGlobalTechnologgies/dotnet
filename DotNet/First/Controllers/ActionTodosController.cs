using First.Context;
using First.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ActionTodosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ActionTodosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/ActionTodos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        var result =  await _context.Todos!.ToListAsync();
        return result;
    }

    // GET: api/ActionTodos/5
    [HttpGet]
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todo = await _context.Todos!.FindAsync(id);

        if (todo == null)
        {
            return NotFound();
        }

        return todo;
    }

    // PUT: api/ActionTodos/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    public async Task<IActionResult> PutTodo(int id, Todo todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }

        _context.Entry(todo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/ActionTodos
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Todo>> PostTodo(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
    }

    // DELETE: api/ActionTodos/5
    [HttpDelete]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var todo = await _context.Todos!.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TodoExists(int id)
    {
        return _context.Todos!.Any(e => e.Id == id);
    }
}
