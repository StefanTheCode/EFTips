using Microsoft.EntityFrameworkCore;

namespace EFTips;

public class MyDbContext : DbContext
{
    public DbSet<MyEntity> MyEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("InMemoryDb");
    }
}