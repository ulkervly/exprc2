using Microsoft.AspNetCore.Mvc;

namespace Business.MVCc.Controllers
{
    public class HomeController : Controller
    {
        

        
        public IActionResult Index()
        {
            return View();
        }

       
    }
}