using LMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.ModelConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
       builder.ToTable(nameof(Category));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(15).IsRequired();
        builder.Property(c=>c.Description).HasMaxLength(100).IsRequired();

    }
}
