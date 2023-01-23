using Microsoft.AspNetCore.Mvc;


namespace Todo2811.Controllers
{
    [ApiController]

    public class HomeController : ControllerBase{

        [HttpGet("/home")]
        public string Get(){
            return "Hello World!!!!";
        }

    }
    
}