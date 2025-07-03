using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.DTOs;
using ProyectAntivirusBackend.Models;

[Route("api/[controller]")]
[ApiController]
public class ServiceTypesController : ControllerBase
{
	private readonly ApplicationDbContext _context;

	public ServiceTypesController(ApplicationDbContext context)
	{
		_context = context;
	}

	// GET
	[HttpGet]
	public async Task<ActionResult<IEnumerable<ServiceTypeDTO>>> GetServiceTypes()
	{
		var serviceTypes = await _context.ServiceTypes
			.Include(st => st.Services) // Incluir los servicios relacionados
			.Select(st => new ServiceTypeDTO
			{
				Id = st.Id,
				Name = st.Name,
				Description = st.Description,
				Services = st.Services.Select(s => new ServiceDTO
				{
					Id = s.Id,
					IsActive = s.IsActive,
					ServiceTypeId = s.ServiceTypeId,
					Title = s.Title,
					Description = s.Description,
					Image = s.Image
				}).ToList() // Convertimos la lista de servicios
			})
			.ToListAsync();

		return Ok(serviceTypes);
	}


	// GET
	[HttpGet("{id}")]
	public async Task<ActionResult<ServiceTypeDTO>> GetServiceType(int id)
	{
		var serviceType = await _context.ServiceTypes
			.Include(st => st.Services)
			.FirstOrDefaultAsync(st => st.Id == id);

		if (serviceType == null)
		{
			return NotFound();
		}

		var serviceTypeDTO = new ServiceTypeDTO
		{
			Id = serviceType.Id,
			Name = serviceType.Name,
			Description = serviceType.Description,
			Services = serviceType.Services.Select(s => new ServiceDTO
			{
				Id = s.Id,
				IsActive = s.IsActive,
				ServiceTypeId = s.ServiceTypeId,
				Title = s.Title,
				Description = s.Description,
				Image = s.Image
			}).ToList()
		};

		return Ok(serviceTypeDTO);
	}


	// POST
	[HttpPost]
	public async Task<ActionResult<ServiceTypeDTO>> PostServiceType(CreateServiceTypeDTO createServiceTypeDTO)
	{
		var serviceType = new ServiceType
		{
			Name = createServiceTypeDTO.Name,
			Description = createServiceTypeDTO.Description
		};

		_context.ServiceTypes.Add(serviceType);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetServiceType), new { id = serviceType.Id }, new ServiceTypeDTO
		{
			Id = serviceType.Id,
			Name = serviceType.Name,
			Description = serviceType.Description,
			Services = new List<ServiceDTO>()
		});
	}


	// PUT
	[HttpPut("{id}")]
	public async Task<IActionResult> PutServiceType(int id, ServiceType serviceType)
	{
		if (id != serviceType.Id)
		{
			return BadRequest();
		}

		_context.Entry(serviceType).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!ServiceTypeExists(id))
			{
				return NotFound();
			}
			else
			{
				throw;
			}
		}

		return NoContent();
	}

	// DELETE
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteServiceType(int id)
	{
		var serviceType = await _context.ServiceTypes.FindAsync(id);
		if (serviceType == null)
		{
			return NotFound();
		}

		_context.ServiceTypes.Remove(serviceType);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool ServiceTypeExists(int id)
	{
		return _context.ServiceTypes.Any(e => e.Id == id);
	}
}
