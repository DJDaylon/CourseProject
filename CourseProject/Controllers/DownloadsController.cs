using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class DownloadsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
