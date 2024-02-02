namespace HairSalon.Models;
public class Stylist
{
    public int StylistId { get; set; }
    public string Name { get; set; }
    public string About { get; set; }
    public DateTime DateAdded { get; set; }
    public List<Client> Clients { get; set; }
}
