using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Services;
using Microsoft.AspNetCore.Http;
using ActorsAPI.Services;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : Controller
{
    private readonly ILogger<ActorController> _logger;
    private readonly IActorServices _actorService;

    public ActorController(ILogger<ActorController> logger, IActorServices actorServices)
    {
        _logger = logger;
        _actorService = actorServices;
    }

    /// <summary>
    /// Obtiene todos los registros de actor
    /// </summary>
    /// <remarks>
    /// **Ejemplo:**
    ///     
    ///     GET /api/actor/
    ///     
    /// </remarks>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="500">Hubo un problema al obtener los registros</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>   
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Actor>), 200)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<Actor> actorTemp = _actorService.Get();
            return Ok(actorTemp);
        }
        catch (Exception)
        {
            _logger.LogError("Un error registrado al obtener Actores");
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Obtiene un registro de actor
    /// </summary>
    /// <remarks>
    /// **Ejemplo:**
    ///     
    ///     GET /api/actor/c8fda22e-187e-4295-b171-d42f47f798db
    ///     
    /// </remarks>
    /// <param name="Id">Id del actor</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns> 
    [HttpGet]
    [Route("{Id}")]
    [ProducesResponseType(typeof(Actor), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(Guid Id)
    {
        try
        {
            var actorTemp = _actorService.Get(Id);
            return Ok(actorTemp);
        }
        catch (Exception)
        {
            _logger.LogError("Un error registrado al obtener Actor");
            return NotFound();
        }
    }

    /// <summary>
    /// Modifica un registro de actor
    /// </summary>
    /// <remarks>
    /// **Ejemplo:**
    ///     
    ///     PUT /api/actor/c8fda22e-187e-4295-b171-d42f47f798db
    /// 
    ///     {
    ///        "Name": "Nombre de ejemplo",
    ///        "Age": "Descripción de ejemplo",
    ///        "Bio": "Biografia de ejemplo",
    ///        "Movies": [ ** movies here (if exist) ** ]
    ///     }
    ///     
    /// </remarks>
    /// <param name="Id">Id del actor</param>
    /// <param name="actor">Datos del actor modificados</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>
    [HttpPut]
    [Route("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(Guid Id, [FromBody] Actor actor)
    {
        try
        {
            _actorService.Put(Id, actor);
            return Ok();
        }
        catch (Exception)
        {
            _logger.LogError("Un error registrado al modificar Actor");
            return BadRequest();
        }
    }

    /// <summary>
    /// Crea un nuevo registro de actor
    /// </summary>
    /// /// <remarks>
    /// **Ejemplo:**
    /// 
    ///     POST /api/actor/
    ///     
    ///     {
    ///        "Name": "Nombre de ejemplo",
    ///        "Age": "Descripción de ejemplo",
    ///        "Bio": "Biografia de ejemplo",
    ///        "Movies": [ ** movies here (if exist) ** ]
    ///     }
    ///     
    /// </remarks>
    /// <param name="actor">El actor que se va a agregar</param>
    /// <response code="200">La operación se realizó correctamente</response>
    /// <response code="400">El usuario ingreso un valor inválido</response>
    /// <returns>Regresa el estado de exito/fracaso de la operación</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] Actor actor)
    {
        try
        {
            _actorService.Post(actor);
            return Ok();
        }
        catch (Exception)
        {
            _logger.LogError("Un error registrado al agregar Actor");
            return BadRequest();
        }
    }

    /// <summary>
    /// Elimina el registro de un actor 
    /// </summary>
    /// /// <remarks>
    /// **Ejemplo:**
    ///
    ///     DELETE /api/actor/c8fda22e-187e-4295-b171-d42f47f798db
    ///
    /// </remarks>
    /// <param name="Id">Id del actor</param>
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
            _actorService.Delete(Id);
            return Ok();
        }
        catch (Exception)
        {
            _logger.LogError("Un error registrado al eliminar Actor");
            return BadRequest();
        }
    }
}
