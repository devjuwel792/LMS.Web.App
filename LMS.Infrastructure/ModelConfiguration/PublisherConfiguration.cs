using LMS.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.ModelConfiguration;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable(nameof(Publisher));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(15).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(100);
    }
}