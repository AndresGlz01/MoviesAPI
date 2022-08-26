using MoviesAPI.Models;
using Swashbuckle.AspNetCore.Filters;

namespace MoviesAPI.Services;

public class ActorExampleProvider : IExamplesProvider<Actor>
{
    public Actor GetExamples()
    {
        return new Actor()
        {
            ActorId = Guid.NewGuid(),
            Name = "Nombre de ejemplo",
            Age = 30,
            Bio = "Biografía de ejemplo",
            Movies = null
        };
    }
}
