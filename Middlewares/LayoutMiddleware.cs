namespace CherryShop.Middlewares;

public class LayoutMiddleware
{
    private readonly RequestDelegate _next;

    public LayoutMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var requestPath = context.Request.Path.Value;

        if (requestPath.StartsWith("/admin"))
        {
            context.Items["Layout"] = "~/Views/Shared/_AdminLayout.cshtml";
        }
        else
        {
            context.Items["Layout"] = "~/Views/Shared/_Layout.cshtml";
        }

        await _next(context);
    }
}
