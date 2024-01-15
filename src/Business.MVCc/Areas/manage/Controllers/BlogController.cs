using Business.Busines.Exceptions.Blog;
using Business.Busines.Services.Interfaces;
using Business.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Business.MVCc.Areas.manage.Controllers
{
    [Area("manage")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            try
            {
                await _blogService.CreateAsync(blog);

            }
            catch (BlogInvalidImageFileException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(blog);
            }
            catch (NullReferenceException ex)
            {

                return View("error");
            }

            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(blog);
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}
