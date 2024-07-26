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
        builder.Property(c => c.Description).HasMaxLength(100);
        builder.HasData(new
        {
            Id = (long)1,
            Name = "UnCategoried",
            RootId = (long)0,
            CreateBy = (long)0,
            CreatedDate = DateTimeOffset.Now,
            IsDeleted = false,
            UpdateBy = (long)0,
            UpdatedDate = DateTimeOffset.Now,
            Default = true,
        });
    }
}