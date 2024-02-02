using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      return View(model);
    }

    public ActionResult Details(int stylistId)
    {
      Stylist targetStylist = _db.Stylists
          .Include(stylist => stylist.Clients)
          .FirstOrDefault(stylist => stylist.StylistId == stylistId);
      return View(targetStylist);
    }
  }
}
