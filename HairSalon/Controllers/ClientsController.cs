using Microsoft.AspNetCore.Mvc.Rendering;
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
        List<Client> clients = _db.GetClientList();
        ViewBag.PageTitle = "All Clients";
        return View(clients);
    }

    public ActionResult Create(int? id)
    {
        SelectList stylistList = _db.StylistSelectList(id);
        if (!stylistList.Any())
        {
            return RedirectToAction("Create", "Stylists");
        }
        Dictionary<string, object> model = new() {
            {"Client", new Client()},
            {"SelectList", stylistList },
            {"Usage", "create"},
        };
        ViewBag.PageTitle = "Add New Client";
        return View("Form", model);
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
        Client thisClient = _db.GetClient(id);
        ViewBag.PageTitle = $"{thisClient.Name}";
        
        return View(thisClient);
    }
    public ActionResult Edit(int id)
    {
        Client thisClient = _db.GetClient(id);
        SelectList stylistList = _db.StylistSelectList(thisClient.StylistId);
        ViewBag.PageTitle = $"Editing {thisClient.Name}";
        Dictionary<string, object> model = new() {
            {"Client", thisClient},
            {"SelectList", stylistList },
            {"Usage", "edit"},
        };
        return View("Form", model);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
        _db.Clients.Update(client);
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
