using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movie.Infrastructure.Configurations;

public class MovieConfig : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(y => y.Year)
            .IsRequired();

        builder.HasOne(m => m.Director)
            .WithMany()
            .HasForeignKey(m => m.DirectorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
