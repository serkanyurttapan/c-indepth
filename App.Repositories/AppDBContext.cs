using Microsoft.EntityFrameworkCore;
using Repositories.Products;

namespace Repositories;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}