using CherryShop.Middlewares.FileProduct.FileReference;

namespace CherryShop.Models.FileProduct.IFileReferenceEntity;

public interface IFileReferenceEntity
{
    ICollection<FileReference> FileReferences{get;set;}
}