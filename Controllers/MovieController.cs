using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Services;
using Microsoft.AspNetCore.Http;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;
    private readonly IMovieServices _movieService;

    public MovieController(ILogger<MovieController> logger, IMovieServices MovieService)
    {
        _logger = logger;
        _movieService = MovieService;
    }

    /// <summary>
    /// Obtiene todos los registros de película
    /// </summary>
    /// <remarks>
    /// **Ejemplo:**
    ///     
    ///     GET /api/movie/
    ///     
    /// </remarks>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="500">Hubo un problema al obtener los registros</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>  
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<Movie> MoviesTemp = _movieService.Get();
            return Ok(MoviesTemp);
        }
        catch (Exception)
        {

            return StatusCode(500);
        }
    }

    /// <summary>
    /// Obtiene un registro de película
    /// </summary>
    /// <remarks>
    /// **Ejemplo:**
    ///     
    ///     GET /api/movie/c8fda22e-187e-4295-b171-d42f47f798db
    ///     
    /// </remarks>
    /// <param name="Id">Id de la película</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>    
    [HttpGet]
    [Route("{Id}")]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(Guid Id)
    {
        try
        {            
            return Ok(_movieService.Get(Id));
        }
        catch (Exception)
        {

            return NotFound();
        }
    }

    /// <summary>
    /// Modifica un registro de película
    /// </summary>
    /// <remarks>
    /// **Ejemplo:**
    ///     
    ///     PUT /api/movie/c8fda22e-187e-4295-b171-d42f47f798db
    /// 
    ///     {
    ///        "Title": "Título de ejemplo",
    ///        "Budget": 1234567890,
    ///        "Description": "Descripción de ejemplo",
    ///        "FechaEstreno": "2022-08-25T16:21:39.2757095-05:00",
    ///        "Genres": [ ** genres here (if exist) ** ],
    ///        "Actors": [ ** actors here (if exist) ** ]
    ///     }
    ///     
    /// </remarks>
    /// <param name="Id">Id de la película</param>
    /// <param name="movie">Datos de la pelicula modificados</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>
    [HttpPut]
    [Route("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(Guid Id, [FromBody] Movie movie)
    {
        try
        {
            _movieService.Put(Id, movie);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Crea un nuevo registro de película
    /// </summary>
    /// /// <remarks>
    /// **Ejemplo:**
    /// 
    ///     POST /api/movie/
    ///     
    ///     {
    ///        "Title": "Título de ejemplo",
    ///        "Budget": 1234567890,
    ///        "Description": "Descripción de ejemplo",
    ///        "FechaEstreno": "2022-08-25T16:21:39.2757095-05:00",
    ///        "Genres": [ ** genres here (if exist) ** ],
    ///        "Actors": [ ** actors here (if exist) ** ]
    ///     }
    ///     
    /// </remarks>
    /// <param name="movie">La película que se va a agregar</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] Movie movie)
    {
        try
        {
            _movieService.Post(movie);
            return Ok();
        }
        catch (Exception)
        {

            return BadRequest();
        }
    }

    /// <summary>
    /// Elimina el registro de una película 
    /// </summary>
    /// /// <remarks>
    /// **Ejemplo:**
    ///
    ///     DELETE /api/movie/c8fda22e-187e-4295-b171-d42f47f798db
    ///
    /// </remarks>
    /// <param name="Id">Id de la película</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>
    [HttpDelete]
    [Route("{Id}")]
    [Produces("text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(Guid Id)
    {
        try
        {
            _movieService.Delete(Id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex);
        }
    }
}
