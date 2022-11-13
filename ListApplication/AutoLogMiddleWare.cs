public class AutoLogMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public AutoLogMiddleWare(RequestDelegate next, ILogger<AutoLogMiddleWare> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        if ((context.Session.GetString("traceId") ?? "") == "")
        {
            context.Session.SetString("traceId", context.Session.Id);
        }
        _logger.LogDebug(context.Session.GetString("traceId") + ' ' + context.Request.Method + ' ' + context.Request.Path+context.Request.QueryString.ToString());
        await _next(context);

    }
}
