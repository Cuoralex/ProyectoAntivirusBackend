using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.DTOs;

[Route("api/v1/localities")]
[ApiController]
public class LocalityController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public LocalityController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/v1/localities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LocalityDTO>>> GetLocalities()
    {
        var localities = await _context.Localities.ToListAsync();
        if (!localities.Any()) return NotFound("No hay localidades registradas.");

        return Ok(_mapper.Map<List<LocalityDTO>>(localities));
    }

    // GET: api/v1/localities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LocalityDTO>> GetLocality(int id)
    {
        var locality = await _context.Localities.FindAsync(id);
        if (locality == null) return NotFound("Localidad no encontrada.");

        return Ok(_mapper.Map<LocalityDTO>(locality));
    }
}
