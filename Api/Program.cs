using Api;                     // pour EcommerceContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Utilise la DB en mémoire
builder.Services.AddDbContext<EcommerceContext>(opt =>
    opt.UseInMemoryDatabase("EcomDb"));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Seed de données
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EcommerceContext>();
    db.Products.AddRange(
        new Api.Models.Product { Name = "Chaussures", Price = 59.99M },
        new Api.Models.Product { Name = "T-shirt", Price = 19.99M },
        new Api.Models.Product { Name = "Pantalon", Price = 39.99M }
    );
    db.Users.AddRange(
        new Api.Models.User { Username = "alice", Email = "alice@email.com" },
        new Api.Models.User { Username = "bob", Email = "bob@email.com" }
    );
    db.SaveChanges();
    db.Orders.Add(new Api.Models.Order { UserId = 1, OrderDate = DateTime.UtcNow });
    db.SaveChanges();
    db.OrderItems.AddRange(
        new Api.Models.OrderItem { OrderId = 1, ProductId = 1, Quantity = 2 },
        new Api.Models.OrderItem { OrderId = 1, ProductId = 2, Quantity = 1 }
    );
    db.SaveChanges();
}

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
