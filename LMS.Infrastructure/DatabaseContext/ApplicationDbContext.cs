using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.DatabaseContext;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
     //modelBuilder.Model.GetEntityTypes().SelectMany(x=>x.GetForeignKeys()).ToList().ForEach(x=>base.OnModelCreating(modelBuilder));
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
