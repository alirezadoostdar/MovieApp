using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly MovieDbContext context;

    public GenreRepository(MovieDbContext context)
    {
        this.context = context;
    }

    public void Add(Genre genre)
    {
        context.Genres.Add(genre);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var genre = context.Genres.FirstOrDefault(x => x.Id == id);
        if (genre is null)
            throw new KeyNotFoundException($"Not Found Genre by Id {id}");
        context.Genres.Remove(genre);
        context.SaveChanges();
    }

    public IEnumerable<Genre> GetAll()
    {
        return context.Genres.ToList();
    }

    public bool IsExists(string title)
    {
        return context.Genres.Any(x => x.Title == title);
    }

    public bool IsUsed(int id)
    {
        return context.MovieGenres.Any(x => x.GenreId == id);
    }

    public void Update(Genre genre)
    {
        var gen = context.Genres.FirstOrDefault(x => x.Id == genre.Id);
        if (gen is null)
            throw new KeyNotFoundException($"Genre not found by Id {genre.Id}");
        gen.Title = genre.Title;
        context.Entry(gen).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        context.SaveChanges();
    }
}
