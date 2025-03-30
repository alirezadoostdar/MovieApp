using Microsoft.EntityFrameworkCore;
using Movie.Domain.Entities;
using Movie.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Infrastructure;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MovieConfig());
        modelBuilder.ApplyConfiguration(new DirectorConfig());
        modelBuilder.ApplyConfiguration(new GenreConfig());
    }

    public DbSet<Film> Films { get; set; }

    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
}
