using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CherryShop.Models;

public class Contact
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id {get;set;}

    [Required(ErrorMessage = "Filed required")]
    [Display(Name = "Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Filed required")]
    [Display(Name = "Sname")]

    public string? Surname { get; set; }
    [Required(ErrorMessage = "Filed required")]
    [Display(Name = "Email")]

    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Filed required")]
    [Display(Name = "Comment")]
    public string? Comment { get; set; }
}