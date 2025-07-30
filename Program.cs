var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddLogging();

var app = builder.Build();

app.UseHttpsRedirection();


app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TokenAuthenticationMiddleware>();
app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseAuthorization();
app.MapControllers();
app.Run();