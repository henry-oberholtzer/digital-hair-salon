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
      List<Stylist> Stylists = _db.Stylists.Include(stylist => stylist.Clients).ToList();
      return View(Stylists);
    }

    public ActionResult Create()
    {
      ViewBag.DateNow = DateTime.Now.ToString("dd-MM-yyyy");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      stylist.DateAdded = DateTime.Now; // prevents client side manipulation
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Stylist targetStylist = _db.Stylists
          .Include(stylist => stylist.Clients)
          .FirstOrDefault(stylist => stylist.StylistId == id);
      return View(targetStylist);
    }

    [HttpPost]
    public ActionResult Delete(int stylistid)
    {
      Stylist targetStylist = _db.Stylists
          .FirstOrDefault(stylist => stylist.StylistId == stylistid);
      _db.Stylists.Remove(targetStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}