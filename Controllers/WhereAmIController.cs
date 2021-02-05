using Microsoft.AspNetCore.Mvc;

namespace CSharp_Traning.Controllers
{
    public class WhereAmIController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}