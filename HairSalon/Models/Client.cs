namespace HairSalon.Models;
public class Client
{
    public int ClientId { get; set; }

    public string Name { get; set; }
    public string Notes { get; set; }

    public DateTime DateAdded { get; set; }
    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }

}
