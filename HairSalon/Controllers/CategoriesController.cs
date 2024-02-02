using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ToDoListContext _db;

        public CategoriesController(ToDoListContext db)
        {
            _db = db;
        }
        public ActionResult Details(int id)
        {
            Category thisCategory = _db.Categories
                .Include(category => category.Items)
                .FirstOrDefault(category => category.CategoryId == id);
            return View(thisCategory);
        }
    }
}
