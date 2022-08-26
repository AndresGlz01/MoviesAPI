using MoviesAPI.Models;
using Swashbuckle.AspNetCore.Filters;

namespace MoviesAPI.Services;

public class MovieExampleProvider : IExamplesProvider<Movie>
{
    public Movie GetExamples()
    {
        return new Movie()
        {
            MovieId = Guid.NewGuid(),
            Title = "Título de ejemplo",
            Budget = 180_127_123_12,
            Description = "Descripción de ejemplo",
            FechaEstreno = DateTime.Now,
            Actors = null,
            Genres = null
        };
    }
}
