using CherryShop.Models.Products;

namespace CherryShop.Models.FileProduct;
public class FileProduct<T>
{
    public List<CherryShop.Models.Files.File> File { get; set; }

    public T TProduct { get; set; }
}