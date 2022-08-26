using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;

public class Actor
{
    [Key]
    public Guid ActorId { get; set; }
    public string? Name {get; set; }
    public int Age { get; set; }
    public string? Bio { get; set; }
    public List<Movie>? Movies { get; set; }
}

