using Movie.Application.Dtos;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Services;

public class DirectorService
{
    private readonly IDirectorRepository repository;

    public DirectorService(IDirectorRepository directorRepository)
    {
        repository = directorRepository;
    }

    public void Add(DirectorDto director)
    {
        repository.Add(new Director
        {
            Id = director.Id,
            FullName = director.Title,
            Bio = director.Bio
        });
    }

    public void Update(DirectorDto director)
    {

        repository.Update(new Director { Id = director.Id, FullName = director.Title, Bio = director.Bio });
    }

    public void Delete(int id)
    {
        repository.Delete(id);
    }

    public bool IsUsed(int id)
    {
        return repository.IsUsed(id);
    }

    public IEnumerable<DirectorDto> GetAll()
    {
        return repository.GetAll().Select(x => new DirectorDto(x.Id, x.FullName,x.Bio));
    }
}
