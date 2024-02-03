using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models;
public class HairSalonContext : DbContext
{
  public DbSet<Stylist> Stylists { get; set; }
  public DbSet<Client> Clients { get; set; }
  public HairSalonContext(DbContextOptions options) : base(options) { }

  public SelectList StylistList(int? id = null)
  {
    SelectList stylistList = new(Stylists, "StylistId", "Name");
    if (id != null)
    {
      foreach (SelectListItem stylist in stylistList)
      {
        if (stylist.Value == id.ToString())
        {
          stylist.Selected = true;
        }
      }
    }
    return stylistList;
  }

  public Client GetClient(int id) => Clients.Include(Client => Client.Stylist).FirstOrDefault(client => client.ClientId == id);
}
