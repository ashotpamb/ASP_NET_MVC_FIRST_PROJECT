using CherryShop.Middlewares.FileProduct.FileReference;
using CherryShop.Models;
using CherryShop.Models.Menus;
using CherryShop.Models.Products;
using CherryShop.Models.Slider;
using Microsoft.EntityFrameworkCore;

namespace CherryShop.Data;

public class DatabaseContext : DbContext
{
   public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contact {get;set;}
    public DbSet<Product> Products {get;set;}
    public DbSet<CherryShop.Models.Files.File> Files {get;set;}
    public DbSet<FileReference> FileRefernces {get;set;}

    public DbSet<Menu> Menus {get;set;}
    public DbSet<CherryShop.Models.Slider.Slider> Slides {get;set;}
}