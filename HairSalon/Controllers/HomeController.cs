using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("/a-photo")]
        public ActionResult FavoritePhotos()
        {
            return View();
        }
    }
}
