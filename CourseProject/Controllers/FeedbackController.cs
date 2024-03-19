using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
