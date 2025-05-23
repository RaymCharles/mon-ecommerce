using Api;                     // pour EcommerceContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Utilise la DB en mémoire
builder.Services.AddDbContext<EcommerceContext>(opt =>
    opt.UseInMemoryDatabase("EcomDb"));

builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();
