using Microsoft.AspNetCore.Mvc;

namespace Business.MVCc.Areas.manage.Controllers
{
    [Area("manage")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
