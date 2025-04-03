using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Infrastructure.Repositories;

public class FilmRepository : IFilmRepository
{
    private readonly MovieDbContext context;

    public FilmRepository(MovieDbContext context)
    {
        this.context = context;
    }

    public void Add(Film film)
    {
        context.Films.Add(film);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var film = context.Films.FirstOrDefault(film => film.Id == id);
        if (film is null)
            throw new KeyNotFoundException($"Not found movie by id {id}");

        context.Films.Remove(film); 
        context.SaveChanges();
    }

    public IEnumerable<Film> GetAll()
    {
        return context.Films.ToList();
    }

    public void Update(Film film)
    {
        var data = context.Films.FirstOrDefault(x => x.Id == film.Id);
        if (data is null)
            throw new KeyNotFoundException($"Not found movie by id {film.Id}");

        data = film;
        context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        context.SaveChanges();
    }
}
