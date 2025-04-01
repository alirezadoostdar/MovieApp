using Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Interfaces;

public interface IDirectorRepository
{
    void Add(Director director);
    IEnumerable<Director> GetAll();
    bool IsUsed(int  id);
}
