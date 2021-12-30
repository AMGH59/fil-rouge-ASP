using Microsoft.AspNetCore.Mvc;

namespace devTalksASP.Controllers
{
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewTopicForm()
        {
            return View();
        }
    }
}
