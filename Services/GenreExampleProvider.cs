using MoviesAPI.Models;
using Swashbuckle.AspNetCore.Filters;

namespace MoviesAPI.Services;

public class GenreExampleProvider : IExamplesProvider<Genre>
{
    public Genre GetExamples()
    {
        return new Genre()
        {
            GenreId = Guid.NewGuid(),
            Name = "Nombre de ejemplo",
            Description = "Descripción de ejemplo",
            Movies = null
        };
    }
}
