using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddLog4Net();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IConfig, Config>();
builder.Services.AddScoped<IData, Data>();
builder.Services.AddScoped<IRemote, Remote>();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v2",
        Title = "ToDo API"
    });
});

var app = builder.Build();

app.UseSession();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseMiddleware<AutoLogMiddleWare>();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseHttpLogging();


app.Run();
