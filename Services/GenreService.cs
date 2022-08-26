using MoviesAPI.Models;
using System.Data;
using System.Linq;

namespace MoviesAPI.Services;

public class GenreService : IGenreService
{
    private readonly MoviesContext _context;
    public GenreService(MoviesContext context)
    {
        _context = context;
    }
    public async Task Delete(Guid id)
    {
        var genre = _context.Genres.Find(id);
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
    }
    public IEnumerable<Genre> Get()
    {
        if (_context.Genres != null)
        {
            return _context.Genres;            
        }
        throw new Exception();
    }
    public Genre Get(Guid id)
    {
        return _context.Genres.Find(id);
    }
    public async Task Post(Genre genre)
    {
        if (genre == null)
        {
            throw new ArgumentException();
        }
        else
        {
            _context.Add(genre);
            await _context.SaveChangesAsync();
        }
    }
    public async Task Put(Guid id, Genre genre)
    {
        var genreTemp = _context.Find<Genre>(id);
        if (genreTemp != null && genre != null)
        {
            genreTemp.Name = genre.Name;
            genreTemp.Description = genre.Description;
            genreTemp.Movies = genre.Movies;
            _context.Update(genreTemp);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException();
        }
    }
}

public interface IGenreService
{
    public IEnumerable<Genre> Get();
    public Genre Get(Guid id);
    public Task Post(Genre genre);
    public Task Delete(Guid id);
    public Task Put(Guid id, Genre genre);
}
