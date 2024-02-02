using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace ToDoList.Controllers;

public class ClientsController : Controller
{
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Client> model = _db.Clients
        .Include(Client => Client.Stylist)
        .ToList();
        return View(model);
    }

    public ActionResult Create(int? id)
    {
        
        SelectList stylistList = new(_db.Stylists, "StylistId", "Name");
        foreach (SelectListItem stylist in stylistList) {
          if (stylist.Value == id.ToString()) {
            stylist.Selected = true;
          }
        }
        ViewBag.StylistSelectList = stylistList;
        
        return View();
    }

    [HttpPost]
    public ActionResult Create(Client Client)
    {
        if (Client.StylistId == 0)
        {
            return RedirectToAction("Create");
        }
        else
        {
            _db.Clients.Add(Client);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }

    public ActionResult Details(int id)
    {
        Client thisClient = _db.Clients
        .Include(Client => Client.Stylist)
        .FirstOrDefault(Client => Client.ClientId == id);
        return View(thisClient);
    }
    public ActionResult Edit(int id)
    {
        Client thisClient = _db.Clients.FirstOrDefault(Client => Client.ClientId == id);
        ViewBag.CategoryId = new SelectList(_db.Stylists, "StylistId", "Name");
        return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client Client)
    {
        _db.Clients.Update(Client);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
        Client thisClient = _db.Clients.FirstOrDefault(Client => Client.ClientId == id);
        _db.Clients.Remove(thisClient);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
