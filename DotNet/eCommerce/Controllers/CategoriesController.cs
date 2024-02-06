using eCommerce.Context;
using eCommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ApiController
    {
        public CategoriesController(ApplicationDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory(ApplicationDbContext context)
        {
            return await context.Category.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Category>> GetCategory(Guid id, ApplicationDbContext context)
        {
            var category = await context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPut]
        public async Task<IActionResult> PutCategory(Guid id, Category category, ApplicationDbContext context)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            context.Entry(category).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id, context))
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

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category, ApplicationDbContext context)
        {
            context.Category.Add(category);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid id, ApplicationDbContext context)
        {
            var category = await context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            context.Category.Remove(category);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(Guid id, ApplicationDbContext context)
        {
            return context.Category.Any(e => e.Id == id);
        }
    }
}
