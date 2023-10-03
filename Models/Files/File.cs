using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CherryShop.Models.Files;

public class File 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}

    public string? Path {get;set;}

    public string? Type {get;set;}

    public string? storagePath {get;set;}

    public string? name {get; set;}

}