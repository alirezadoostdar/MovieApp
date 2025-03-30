using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities;

public class Film
{
    public int Id { get; set; }
    public int DirectorId { get; set; }
    public string Title { get; set; }
    public string Tagline { get; set; }
    public int Year { get; set; }
    public decimal ImbdRate { get; set; }
    public string Description { get; set; }
    public string Poster { get; set; }
    public string Cast { get; set; }
    public DateTime CreateDate { get; set; }
    public Director Director { get; set; }
    public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
}
