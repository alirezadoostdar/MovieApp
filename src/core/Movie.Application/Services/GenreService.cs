using Movie.Application.Dtos;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Services;

public class GenreService
{
    private readonly IGenreRepository repository;

    public GenreService(IGenreRepository repository)
    {
        this.repository = repository;
    }

    public void Add(GenreDto genre)
    {
        repository.Add(new Genre { Id = genre.Id, Title = genre.Title });
    }

    public void Update(GenreDto genre)
    {
        repository.Update(new Genre { Id = genre.Id, Title = genre.Title });

    }

    public void Delete(int id)
    {
        repository.Delete(id);
    }

    public IEnumerable<GenreDto> GetAll() 
    {
        return repository.GetAll().Select(x => new GenreDto { Id =  x.Id, Title = x.Title });
    }

    public bool IsDublicate(string title)
    {
        return repository.IsExists(title);
    }

    public bool IsUsedBefore(int id)
    {
        return repository.IsUsed(id);
    }

}
