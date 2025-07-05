using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.DTOs;
using ServiceModel = ProyectAntivirusBackend.Models.Service;


namespace ProyectAntivirusBackend.Controllers
{
    [Route("api/v1/services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetServices()
        {
            try
            {
                var services = await _context.Services
                    .Include(s => s.ServiceType)
                    .Select(s => new ServiceDTO
                    {
                        Id = s.Id,
                        IsActive = s.IsActive,
                        ServiceTypeId = s.ServiceTypeId,
                        ServiceTypeName = s.ServiceType != null ? s.ServiceType.Name : "Sin Tipo",
                        Title = s.Title,
                        Description = s.Description,
                        Image = s.Image
                    })
                    .ToListAsync();

                return Ok(services);
            }
            catch (Exception ex)
            {
                Console.WriteLine("💥 Error en GetServices: " + ex.Message);
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();

            return Ok(new ServiceDTO
            {
                Id = service.Id,
                IsActive = service.IsActive,
                ServiceTypeId = service.ServiceTypeId,
                Title = service.Title,
                Description = service.Description,
                Image = service.Image
            });
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> PostService(CreateServiceDTO createServiceDTO)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(createServiceDTO.ServiceTypeId);
            if (serviceType == null)
            {
                return BadRequest($"El ServiceTypeId {createServiceDTO.ServiceTypeId} no existe.");
            }

            var service = new ServiceModel
            {
                IsActive = true,
                ServiceTypeId = createServiceDTO.ServiceTypeId,
                ServiceType = serviceType,
                Title = createServiceDTO.Title,
                Description = createServiceDTO.Description,
                Image = createServiceDTO.Image
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetService), new { id = service.Id }, new ServiceDTO
            {
                Id = service.Id,
                IsActive = service.IsActive,
                ServiceTypeId = service.ServiceTypeId,
                Title = service.Title,
                Description = service.Description,
                Image = service.Image
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, CreateServiceDTO createServiceDTO)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();

            var serviceType = await _context.ServiceTypes.FindAsync(createServiceDTO.ServiceTypeId);
            if (serviceType == null)
            {
                return BadRequest($"El ServiceTypeId {createServiceDTO.ServiceTypeId} no existe.");
            }

            service.ServiceTypeId = createServiceDTO.ServiceTypeId;
            service.ServiceType = serviceType;
            service.Title = createServiceDTO.Title;
            service.Description = createServiceDTO.Description;
            service.Image = createServiceDTO.Image;

            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();

            _context.Services.Remove(service);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest("No se puede eliminar este servicio porque está relacionado con otros datos.");
            }

            return NoContent();
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateServiceStatusDTO dto)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();

            service.IsActive = dto.IsActive;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
