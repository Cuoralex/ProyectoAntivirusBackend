using Microsoft.AspNetCore.Mvc;
using ProyectAntivirusBackend.Services;
using ProyectAntivirusBackend.Models;
using ProyectAntivirusBackend.DTOs; // ← Asegúrate de importar el namespace correcto
using System.Collections.Generic;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using ProyectAntivirusBackend.Data;

namespace ProyectAntivirusBackend.Controllers
{
    [Route("api/v1/opportunity-type")]
    [ApiController]
    public class OpportunityTypeController : ControllerBase
    {
        private readonly OpportunityTypeService _service;
        private readonly ApplicationDbContext _context;

        public OpportunityTypeController(OpportunityTypeService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpportunityType>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OpportunityType>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<OpportunityType>> Create([FromBody] CreateOpportunityTypeDTO dto)
        {
            var category = await _context.Categories.FindAsync(dto.CategoryId);
            if (category == null)
                return BadRequest("La categoría especificada no existe.");

            var opportunityType = new OpportunityType
            {
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Categories = category
            };

            await _service.AddAsync(opportunityType);
            return CreatedAtAction(nameof(GetById), new { id = opportunityType.Id }, opportunityType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateOpportunityTypeDTO dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            var category = await _context.Categories.FindAsync(dto.CategoryId);
            if (category == null)
                return BadRequest("La categoría especificada no existe.");

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.CategoryId = dto.CategoryId;
            existing.Categories = category;

            await _service.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
