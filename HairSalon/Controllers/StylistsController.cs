using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers;

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
      ViewBag.PageTitle = $"All Stylists";
      return View(Stylists);
    }

    public ActionResult Create()
    {
      ViewBag.DateNow = DateTime.Now.ToString("dd-MM-yyyy");
      ViewBag.PageTitle = $"Add New Stylist";
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
      ViewBag.PageTitle = $"{targetStylist.Name}";
      return View(targetStylist);
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      Stylist targetStylist = _db.Stylists
          .FirstOrDefault(stylist => stylist.StylistId == id);
      _db.Stylists.Remove(targetStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
