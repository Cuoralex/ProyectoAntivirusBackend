using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.Models;
using ProyectAntivirusBackend.DTOs;

namespace ProyectAntivirusBackend.Controllers
{
    [Route("api/v1/sectors")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectorDTO>>> GetSectors()
        {
            var sectors = await _context.Sectors
                .Select(s => new SectorDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                })
                .ToListAsync();
            return Ok(sectors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SectorDTO>> GetSector(int id)
        {
            var sector = await _context.Sectors.FindAsync(id);
            if (sector == null) return NotFound();
            return Ok(new SectorDTO { Id = sector.Id, Name = sector.Name, Description = sector.Description });
        }

        [HttpGet("{id}/opportunities")]
        public async Task<ActionResult<IEnumerable<OpportunityDTO>>> GetOpportunitiesBySector(int id)
        {
            var opportunities = await _context.Opportunities
                .Where(o => o.SectorId == id)
                .Select(o => new OpportunityDTO
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    Modality = o.Modality,
                    SectorName = o.Sectors.Name,
                    OpportunityTypeName = o.OpportunityTypes.Name,
                    LocalityCity = o.Localities.City,
                    InstitutionName = o.Institutions.Name,
                    RatingId = o.RatingId
                })
                .ToListAsync();

            if (!opportunities.Any())
            {
                return NotFound($"No hay oportunidades asociadas al sector con ID {id}");
            }

            return Ok(opportunities);
        }


        [HttpPost]
        public async Task<ActionResult<SectorDTO>> PostSector(Sector sector)
        {
            _context.Sectors.Add(sector);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSector), new { id = sector.Id }, new SectorDTO { Id = sector.Id, Name = sector.Name, Description = sector.Description });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSector(int id, [FromBody] CreateSectorDTO dto)
        {
            var sector = await _context.Sectors.FindAsync(id);
            if (sector == null) return NotFound();

            sector.Name = dto.Name;
            sector.Description = dto.Description;

            _context.Entry(sector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Sectors.Any(e => e.Id == id))
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(int id)
        {
            var sector = await _context.Sectors.FindAsync(id);
            if (sector == null) return NotFound();
            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}