using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;

public class Genre
{
    [Key]
    public Guid GenreId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<Movie>? Movies { get; set; }
}
