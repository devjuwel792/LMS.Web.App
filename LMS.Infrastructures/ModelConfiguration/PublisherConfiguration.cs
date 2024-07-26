using LMS.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LMS.Infrastructure.ModelConfiguration;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        long id = 1;
        long userid = 0;

        builder.ToTable(nameof(Publisher));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(15).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(100);
        builder.HasData(new
        {
            Id = id,
            Name = "UnKnown",
            CreateBy = userid,
            CreatedDate = DateTimeOffset.Now,
            IsDeleted = false,
            UpdateBy = userid,
            UpdatedDate = DateTimeOffset.Now,
        });
    }
}