using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// Controller to manage requests.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly IRequestService _service;

    /// <summary>
    /// Initializes a new instance of the RequestsController class.
    /// </summary>
    /// <param name="service">Service to manage requests.</param>
    public RequestsController(IRequestService service) { _service = service; }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves all requests", Description = "Returns a list of all requests.")]
    [ProducesResponseType(typeof(IEnumerable<RequestDto>), 200)]
    public async Task<ActionResult<IEnumerable<RequestDto>>> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retrieves a request by ID", Description = "Returns a specific request based on the provided ID.")]
    [ProducesResponseType(typeof(RequestDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<RequestDto>> GetById(int id) => Ok(await _service.GetByIdAsync(id));

    [HttpPost]
    [SwaggerOperation(Summary = "Adds a new request", Description = "Creates a new request and returns the created entity.")]
    [ProducesResponseType(typeof(RequestDto), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Add([FromBody] RequestDto dto)
    {
        await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Updates an existing request", Description = "Updates a request based on the provided ID and DTO.")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] RequestDto dto)
    {
        if (id != dto.Id) return BadRequest();
        await _service.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletes a request by ID", Description = "Removes a request from the system based on the provided ID.")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

/// <summary>
/// Interface defining operations for request management.
/// </summary>
public interface IRequestService
{
    Task<IEnumerable<RequestDto>> GetAllAsync();
    Task<RequestDto?> GetByIdAsync(int id);
    Task AddAsync(RequestDto dto);
    Task UpdateAsync(RequestDto dto);
    Task DeleteAsync(int id);
}
