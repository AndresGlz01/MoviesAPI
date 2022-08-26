using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;

public class Movie
{
    [Key]
    public Guid MovieId { get; set; }
    public string? Title { get; set; }
    public double Budget { get; set; }  
    public string? Description { get; set;}  
    public DateTime? FechaEstreno { get; set; }
    public List<Genre>? Genres { get; set; }
    public List<Actor>? Actors { get; set; }
}