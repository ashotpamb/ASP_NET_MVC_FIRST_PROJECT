using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CherryShop.Models.FileProduct.IFileReferenceEntity;
using CherryShop.Middlewares.FileProduct.FileReference;

namespace CherryShop.Models.Products;

public class Product 
{

    public Product()
    {
        FileReferences = new List<FileReference>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }


    public string? Description { get; set; }
    public ICollection<FileReference> FileReferences { get; set; }
}