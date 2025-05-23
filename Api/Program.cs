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
        new Api.Models.Product {
            Name = "T-shirt Carhartt",
            Price = 39.99M,
            Image = "https://cdn.media.amplience.net/i/carhartt_wip/I026391_30Y_XX-ST-01/s-s-chase-t-shirt-dark-fir-gold-2003.png?$pdp_02$&fmt=auto&qlt=default",
            Category = "vetement"
        },
        new Api.Models.Product {
            Name = "iPhone 14 Pro Max",
            Price = 1299.00M,
            Image = "https://media.ldlc.com/r1600/ld/products/00/05/97/77/LD0005977700.jpg",
            Category = "electronique"
        },
        new Api.Models.Product {
            Name = "Tondeuse BOSCH 18V-32-300",
            Price = 199.99M,
            Image = "https://www.bosch-diy.com/imagestorage/fr-fr/citymower-18v-32-300-100053447-hires-png-rgb-oneux-359150_w_1500_h_842.png",
            Category = "jardinage"
        }
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
