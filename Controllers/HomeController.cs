using Microsoft.AspNetCore.Mvc;
using Todo2811.Data;
using Todo2811.Models;

namespace Todo2811.Controllers
{
    [ApiController]

    public class HomeController : ControllerBase
    {

        [HttpGet("/")]
        public List<TodoModel> Get([FromServices] AppDBContext context)
        {
            return context.Todos.ToList();
        }

        [HttpGet("{id:int}")]
        public TodoModel GetById([FromRoute] int id, [FromServices] AppDBContext context)
        {
            return context.Todos.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("/")]
        public TodoModel Post(TodoModel todo, [FromServices] AppDBContext context)
        {
            context.Add(todo);
            context.SaveChanges();
            return todo;
        }

        [HttpPut("/{id:int}")]
        public TodoModel Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo,
            [FromServices] AppDBContext context)
        {

            var model = context.Todos.FirstOrDefault<TodoModel>(x => x.Id == id);
            if (model == null)
                return  todo;

                model.Title = todo.Title;
                model.Done = todo.Done;

                context.Todos.Update(model);
                context.SaveChanges();
                return model;
        }

        [HttpDelete("/{id:int}")]
        public TodoModel Delete(
            [FromRoute] int id,
            [FromServices] AppDBContext context){

                var model = context.Todos.FirstOrDefault(x=> x.Id == id);
                context.Todos.Remove(model);
                context.SaveChanges();
                return model;

        }


    }

}