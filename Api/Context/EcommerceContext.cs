using Microsoft.EntityFrameworkCore;
using Api.Models;    // pour que Product soit connu

namespace Api
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
