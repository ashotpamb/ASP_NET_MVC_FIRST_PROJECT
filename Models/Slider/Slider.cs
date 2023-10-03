using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CherryShop.Middlewares.FileProduct.FileReference;
using CherryShop.Models.FileProduct.IFileReferenceEntity;

namespace CherryShop.Models.Slider;

public class Slider : IFileReferenceEntity
{
    public Slider()
    {
        FileReferences = new List<FileReference>();

    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


    public string? Title { get; set; }
    public string? Description { get; set; }
    public ICollection<FileReference> FileReferences { get; set; }
}