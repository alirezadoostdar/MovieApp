using Movie.Application.Dtos;
using Movie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Services;

public class MovieService
{
    private readonly IFilmRepository repository;

    public MovieService(IFilmRepository repository)
    {
        this.repository = repository;
    }

    public IEnumerable<MovieDto> GetAll()
    {
        return repository.GetAll().Select(x => new MovieDto()
        {
            Id = x.Id,
            Title = x.Title,
            DirectorId = x.DirectorId,
            Description = x.Description,
            CreateDate = x.CreateDate,
            Tagline = x.Tagline,
            ImbdRate = x.ImbdRate,
            Poster = x.Poster,
            Cast = x.Cast,
            Year = x.Year,  
        });
    }

    public void Add(MovieDto movie)
    {
        repository.Add(new Domain.Entities.Film
        {
            Id = movie.Id,
            Title = movie.Title,
            DirectorId = movie.DirectorId,
            Description = movie.Description,
            CreateDate = movie.CreateDate,
            Tagline = movie.Tagline,
            ImbdRate = movie.ImbdRate,
            Poster = movie.Poster,
            Cast = movie.Cast,
            Year = movie.Year,
        });
    }
}
