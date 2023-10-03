using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CherryShop.Models.Menus;

public class Menu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public int? ParentId { get; set; }

    public Menu Parent { get; set; }

    public ICollection<Menu> Submenus { get; set; }
}