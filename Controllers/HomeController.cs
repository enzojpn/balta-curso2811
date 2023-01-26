using Microsoft.AspNetCore.Mvc;
using Todo2811.Data;
using Todo2811.Models;

namespace Todo2811.Controllers
{
    [ApiController]

    public class HomeController : ControllerBase{

        [HttpGet("/home")]
        public List<TodoModel> Get([FromServices] AppDBContext context){
            return context.Todos.ToList();
        }

    }
    
}