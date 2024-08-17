using LMS.Domain.Model.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.ModelConfiguration;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(nameof(Permission));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(15).IsRequired();

        
    }
}