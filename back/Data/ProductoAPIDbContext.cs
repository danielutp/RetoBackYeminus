using back.Model;
using Microsoft.EntityFrameworkCore;

namespace back.Data
{
    public class ProductoAPIDbContext : DbContext
    {
        public ProductoAPIDbContext(DbContextOptions<ProductoAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Products { get; set; }
    }
}
