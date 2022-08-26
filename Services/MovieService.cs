using MoviesAPI.Models;

namespace MoviesAPI.Services;

public class MovieServices : IMovieServices
{
    private readonly MoviesContext _context;
    public MovieServices(MoviesContext context)
    { 
        _context = context;
    }

    public async Task Delete(Guid id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            throw new ArgumentException("La película no existe");
        }
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<Movie> Get()
    {
        if (_context.Movies != null)
        {
            return _context.Movies;            
        }
        throw new Exception();
    }

    public Movie Get(Guid id)
    {
        return _context.Movies.Find(id);
    }

    public async Task Post(Movie movie)
    {
        if (movie == null)
        {
            throw new ArgumentException();
        }
        else
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Put(Guid id, Movie movie)
    {
        var movieTemp = _context.Find<Movie>(id);
        if (movieTemp != null && movie != null)
        {
            movieTemp.Title = movie.Title;
            movieTemp.Description = movie.Description;
            movieTemp.Actors = movie.Actors;
            movieTemp.Genres = movie.Genres;
            movieTemp.Budget = movie.Budget;
            movieTemp.FechaEstreno = movie.FechaEstreno;
            _context.Update(movieTemp);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException();
        }
    }
}

public interface IMovieServices
{
    public IEnumerable<Movie> Get();
    public Movie Get(Guid id);
    public Task Post(Movie movie);
    public Task Delete(Guid id);
    public Task Put(Guid id, Movie movie);
}