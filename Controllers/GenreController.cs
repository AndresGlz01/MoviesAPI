using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Services;
using Microsoft.AspNetCore.Http;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController : Controller
{
    private readonly ILogger<GenreController> _logger;
    private readonly IGenreService _genreService;

    public GenreController(ILogger<GenreController> logger, IGenreService genreService)
    {
        _logger = logger;
        _genreService = genreService;
    }

    /// <summary>
    /// Obtiene todos los registros de género
    /// </summary>
    /// <remarks>
    /// **Ejemplo:**
    ///     
    ///     GET /api/genre/
    ///     
    /// </remarks>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="500">Hubo un problema al obtener los registros</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>      
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Genre>), 200)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<Genre> genresTemp = _genreService.Get();
            return Ok(genresTemp);
        }
        catch (Exception)
        {
            _logger.LogError("Un error registrado al obtener Géneros");
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Obtiene un registro de género
    /// </summary>
    /// <remarks>
    /// **Ejemplo:**
    ///     
    ///     GET /api/genre/c8fda22e-187e-4295-b171-d42f47f798db
    ///     
    /// </remarks>
    /// <param name="Id">Id del género</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>  
    [HttpGet]
    [Route("{Id}")]
    [ProducesResponseType(typeof(Genre), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(Guid Id)
    {
        try
        {
            return Ok(_genreService.Get(Id));
        }
        catch (Exception)
        {
            _logger.LogError("Un error registrado al obtener Genero");
            return NotFound();
        }
    }

    /// <summary>
    /// Modifica un registro de género
    /// </summary>
    /// <remarks>
    /// **Ejemplo:**
    ///     
    ///     PUT /api/movie/c8fda22e-187e-4295-b171-d42f47f798db
    /// 
    ///     {
    ///        "Name": "Nombre de ejemplo",
    ///        "Description": "Descripción de ejemplo",
    ///        "Movies": [ ** movies here (if exist) ** ]
    ///     }
    ///     
    /// </remarks>
    /// <param name="Id">Id del género</param>
    /// <param name="genre">Datos del género modificados</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>
    [HttpPut]
    [Route("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(Guid Id,[FromBody] Genre genre)
    {
        try
        {
            _genreService.Put(Id, genre);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Crea un nuevo registro de género
    /// </summary>
    /// /// <remarks>
    /// **Ejemplo:**
    /// 
    ///     POST /api/genre/
    ///     
    ///     {
    ///        "Name": "Nombre de ejemplo",
    ///        "Description": "Descripción de ejemplo",
    ///        "Movies": [ ** movies here (if exist) ** ]
    ///     }
    ///     
    /// </remarks>
    /// <param name="genre">El género que se va a agregar</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] Genre genre)
    {
        try
        {
            _genreService.Post(genre);
            return Ok();
        }
        catch (Exception)
        {

            return BadRequest();
        }
    }

    /// <summary>
    /// Elimina el registro de un género 
    /// </summary>
    /// /// <remarks>
    /// **Ejemplo:**
    ///
    ///     DELETE /api/genre/c8fda22e-187e-4295-b171-d42f47f798db
    ///
    /// </remarks>
    /// <param name="Id">Id del género</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>
    [HttpDelete]
    [Route("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(Guid Id)
    {
        try
        {
            _genreService.Delete(Id);
            return Ok();
        }
        catch (Exception)
        {
            _logger.LogError("Un error registrado al eliminar Género");            
            return BadRequest();
        }
    }
}
