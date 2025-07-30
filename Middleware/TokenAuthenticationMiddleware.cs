public class TokenAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _validToken = "TechHiveToken123"; // Replace with secure value or config

    public TokenAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

        if (string.IsNullOrEmpty(token) || token != _validToken)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("{\"error\": \"Unauthorized\"}");
            return;
        }

        await _next(context);
    }
}