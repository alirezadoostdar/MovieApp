

namespace Movie.Application.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Tagline { get; set; }
    public string Year { get; set; }
    public decimal ImbdRate { get; set; }
    public string Description { get; set; }
    public string Poster { get; set; }
    public string Cast { get; set; }
    public DateTime CreateDate { get; set; }
}

public class Director
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Bio { get; set; }
}

public class Genre
{
    public int Id { get; set; }
    public string Title { get; set; }
}