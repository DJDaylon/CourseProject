using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
