using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Controllers;
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
        List<Client> clients = _db.Clients
        .Include(Client => Client.Stylist)
        .ToList();
        ViewBag.PageTitle = "All Clients";
        return View(clients);
    }

    public ActionResult Create(int? id)
    {
        SelectList stylistList = _db.StylistList(id);
        if (!stylistList.Any())
        {
            return RedirectToAction("Create", "Stylists");
        }
        ViewBag.StylistSelectList = stylistList;
        ViewBag.PageTitle = "Add New Client";
        return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
        client.DateAdded = DateTime.Now;
        _db.Clients.Add(client);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Client thisClient = _db.Clients
        .Include(Client => Client.Stylist)
        .FirstOrDefault(Client => Client.ClientId == id);
        ViewBag.PageTitle = $"{thisClient.Name}";
        return View(thisClient);
    }
    public ActionResult Edit(int id)
    {
        Client thisClient = _db.Clients.Include(Client => Client.Stylist).FirstOrDefault(Client => Client.ClientId == id);
        ViewBag.StylistSelectList = _db.StylistList();
        ViewBag.PageTitle = $"Editing {thisClient.Name}";
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
        _db.Clients.Remove(_db.GetClient(id));
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
