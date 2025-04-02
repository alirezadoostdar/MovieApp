using Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Interfaces;

public interface IGenreRepository
{
    void Add(Genre genre);
    void Update(Genre genre);
    void Delete(int id);
    IEnumerable<Genre> GetAll();
    bool IsUsed(int id);
    bool IsExists(string title);
}
