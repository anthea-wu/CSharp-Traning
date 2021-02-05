using Microsoft.AspNetCore.Mvc;


namespace CSharp_Traning.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class WhereAmIController : Controller
    {
        
        // GET
        public IActionResult Index()
        {
            return Ok(new {IP = "1.1.1.1", CountryCode = "TW"});
        }
    }
}