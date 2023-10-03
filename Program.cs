using CherryShop.Data;
using CherryShop.Middlewares;
using CherryShop.Services.Rabbit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// builder.Services.AddSingleton<RabbitMqService>();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var env = builder.Environment;
    var connectionString = env.IsDevelopment()
      ? builder.Configuration.GetConnectionString("DefaultConnectionString")
      : builder.Configuration.GetConnectionString("DefaultConnectionStringStage");
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
        
    );
});


var serviceProvider = builder.Services.BuildServiceProvider();
Helper.Initialize(serviceProvider);
var logger = serviceProvider.GetService<ILogger<Program>>();

// Log the database connection status
using (var dbContext = serviceProvider.GetService<DatabaseContext>())
{
    try
    {
        dbContext.Database.OpenConnection();
        logger.LogInformation("Database connection successful.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Database connection failed.");
    }
}
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<LayoutMiddleware>();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin/{controller=Admin}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "products",
        pattern: "admin/products/{controller=Products}/{action=Products}/{id?}");
    endpoints.MapControllerRoute(
        name: "New Product",
        pattern: "admin/new-product/{controller=Products}/{action=New}/{id?}");
    endpoints.MapControllerRoute(
        name: "Remove File",
        pattern: "admin/file-remove/{controller=File}/{action=Remove}/{id?}");
});

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
