using Microsoft.AspNetCore.Mvc;
using Todo2811.Data;
using Todo2811.Models;

namespace Todo2811.Controllers
{
    [ApiController]

    public class HomeController : ControllerBase
    {

        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDBContext context)
         => Ok(context.Todos.ToList());


        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDBContext context)
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todos == null) return NotFound();

            return Ok(todos);
        }

        [HttpPost("/")]
        public IActionResult Post(TodoModel todo, [FromServices] AppDBContext context)
        {
            context.Add(todo);
            context.SaveChanges();
            return Created($"/{todo.Id}", todo);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo,
            [FromServices] AppDBContext context)
        {

            var model = context.Todos.FirstOrDefault<TodoModel>(x => x.Id == id);
            if (model == null)
                return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDBContext context)
        {

            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null) return NotFound();
            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);

        }


    }

}