using Microsoft.AspNetCore.Mvc;
using CSharp_Traning.Models;


namespace CSharp_Traning.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class WhereAmIController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var IP = GeoIpServer.GetCurrentIP();
            var CountryCode = GeoIpServer.GetCurrentCountry(IP);
            return Ok(new {IP, CountryCode = "TW"});
        }
    }
}