using Microsoft.EntityFrameworkCore;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Infrastructure.Repositories;

internal class DirectorRepository : IDirectorRepository
{
    private readonly MovieDbContext context;
    public DirectorRepository(MovieDbContext dbContext)
    {
        context = dbContext;
    }
    public void Add(Director director)
    {
        context.Directors.Add(director);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var director = context.Directors.FirstOrDefault(d => d.Id == id);
        if (director is null)
            throw new Exception($"Not found director by id {id}");
        context.Directors.Remove(director);
        context.SaveChanges();
    }

    public IEnumerable<Director> GetAll()
    {
        return context.Directors.AsNoTracking().ToList();
    }

    public bool IsUsed(int id)
    {
        return context.Films.Any(x => x.DirectorId == id);
    }

    public void Update(Director director)
    {
        //var res = context.Directors.FirstOrDefault(d => d.Id == director.Id);
        //if (res is null)
        //    throw new Exception($"Not found director by id {director.Id}");

        //res.FullName = director.FullName;
        //r

        context.Entry(director).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        context.SaveChanges();
    }
}
