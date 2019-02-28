using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly Assignment2Context _context;

        public TodoController(Assignment2Context context)
        {
            _context = context;

            if (_context.ModelClass.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.ModelClass.Add(new ModelClass { Name = "Item1" });
                _context.SaveChanges();
            }
        }
        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelClass>>> GetTodoItems()
        {
            return await _context.ModelClass.ToListAsync();
        }
        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelClass>> GetTodoItem(long id)
        {
            var todoItem = await _context.ModelClass.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        // GET: api/Todo/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> PutTodoItem(long id, ModelClass item)
        //{
        //    if (id != item.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(item).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<ModelClass>> PostTodoItem(ModelClass item)
        {
            _context.ModelClass.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostTodoItem), new { id = item.Id }, item);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.ModelClass.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.ModelClass.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        // The default HSTS value is 30 days. You may want to change this for 
        //        // production scenarios, see https://aka.ms/aspnetcore-hsts.
        //        app.UseHsts();
        //    }

        //    app.UseDefaultFiles();
        //    app.UseStaticFiles();
        //    app.UseHttpsRedirection();
        //    app.UseMvc();
        //}
    }
}