using System.ComponentModel.DataAnnotations;
namespace rp_ef_maria.Models;

public class Game { 
    public uint GameId{ get; set; }
    public string Title { get; set; } = "";
    
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]

    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; } = "";
    public decimal Price{ get; set; }
}