using CherryShop.Data;
using CherryShop.Models.Menus;

public static class Helper
{
    private static IServiceProvider _serviceProvider;

    public static void Initialize(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public static List<Menu> GetAllMenus()
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        var menus = context.Menus.ToList();
        return menus;
    }
}

