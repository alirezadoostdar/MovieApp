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

    public IEnumerable<Director> GetAll()
    {
        return context.Directors.ToList();
    }

    public bool IsUsed(int id)
    {
        return context.Films.Any(x => x.DirectorId == id);
    }
}
