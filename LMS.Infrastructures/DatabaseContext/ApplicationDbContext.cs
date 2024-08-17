using LMS.Domain.Model.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.DatabaseContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser,ApplicationRole,string>(options)
{
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()).ToList().ForEach(x => base.OnModelCreating(modelBuilder));


        var admin = new IdentityRole("admin");
        admin.NormalizedName = "admin";
        var librarian = new IdentityRole("librarian");
        librarian.NormalizedName = "librarian";
        var student = new IdentityRole("student");
        student.NormalizedName = "student";

        modelBuilder.Entity<IdentityRole>().HasData(student,admin,librarian);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

    }

   
}