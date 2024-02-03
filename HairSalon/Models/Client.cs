using System.ComponentModel.DataAnnotations;

namespace HairSalon.Models;
public class Client
{
    public int ClientId { get; set; }

    [MinLength(1)]
    [MaxLength(255)]
    [Display(Name = "Client Name")]
    [Required]
    public string Name { get; set; }

    [MinLength(1)]
    [MaxLength(255)]
    [Display(Name = "Notes")]
    [Required]
    public string Notes { get; set; }

    public DateTime DateAdded { get; set; }

    [Display(Name = "Stylist")]
    [Required]
    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }

}
