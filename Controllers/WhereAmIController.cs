using Microsoft.AspNetCore.Mvc;
using CSharp_Traning.Models;


namespace CSharp_Traning.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class WhereAmIController : Controller
    {
        private readonly IGeoIpServer _geoIpServer;

        public WhereAmIController(IGeoIpServer geoIpServer)
        {
            _geoIpServer = geoIpServer;
        }
        
        // GET
        public IActionResult Index()
        {
            var CurrentPlace = _geoIpServer.GetCurrentPlace();
            return Ok(CurrentPlace);
        }
    }
}