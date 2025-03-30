using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Infrastructure.Configurations;

public class DirectorConfig : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.FullName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(m => m.Bio)
            .HasMaxLength(2000);
    }
}
