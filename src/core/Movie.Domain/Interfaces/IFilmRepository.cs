using Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Interfaces;

public interface IFilmRepository
{
    void Add(Film film);
    List<Film> GetAll();    
    void Update(Film film);
    void Delete(Film film);

}
