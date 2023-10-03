using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CherryShop.Middlewares.FileProduct.FileReference;

public class FileReference
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get;set;}

    public int ReferenceId {get;set;}
    public string? ReferenceType{get;set;}

    public int FileId{get;set;}

    [ForeignKey("FileId")]

    public CherryShop.Models.Files.File File {get;set;}
    
}