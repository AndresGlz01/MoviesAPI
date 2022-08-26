using MoviesAPI;
using MoviesAPI.Models;

namespace ActorsAPI.Services;

public class ActorServices : IActorServices
{
    private readonly MoviesContext _context;
    public ActorServices(MoviesContext context)
    { 
        _context = context;
    }

    public async Task Delete(Guid id)
    {
        var actor = _context.Actors.Find(id);
        _context.Actors.Remove(actor);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<Actor> Get()
    {
        if (_context.Actors != null)
        {
            return _context.Actors;            
        }
        throw new Exception();
    }

    public Actor Get(Guid id)
    {
        return _context.Actors.Find(id);
    }

    public async Task Post(Actor Actor)
    {
        if (Actor == null)
        {
            throw new ArgumentException();
        }
        else
        {
            _context.Add(Actor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Put(Guid id, Actor actor)
    {
        var actorTemp = _context.Find<Actor>(id);
        if (actorTemp != null && actor != null)
        {
            actorTemp.Name = actor.Name;
            actorTemp.Age = actor.Age;
            actorTemp.Bio = actor.Bio;
            actorTemp.Movies = actor.Movies;
            _context.Update(actorTemp);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException();
        }
    }
}

public interface IActorServices
{
    public IEnumerable<Actor> Get();
    public Actor Get(Guid id);
    public Task Post(Actor Actor);
    public Task Delete(Guid id);
    public Task Put(Guid id, Actor Actor);
}