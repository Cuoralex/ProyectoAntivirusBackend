using Microsoft.AspNetCore.Mvc;
using ProyectAntivirusBackend.Models;
using ProyectAntivirusBackend.Service;

namespace ProyectAntivirusBackend.Controllers
{
    [Route("api/v1/institution")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _service;

        public InstitutionController(IInstitutionService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Institution>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institution>>> GetAll()
        {
            var institutions = await _service.GetAllAsync();

            return Ok(institutions);
        }

        [HttpPost]
        public async Task<ActionResult<Institution>> Create([FromBody] Institution institution)
        {
            await _service.AddAsync(institution);
            
            return CreatedAtAction(nameof(GetById), new { id = institution.Id }, institution);
        }

        [HttpPut]
        public async Task<ActionResult<Institution>> Update([FromBody] Institution institution)
        {
            await _service.UpdateAsync(institution);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var existing = await _service.GetByIdAsync(id);

            if (existing == null) {
                return NotFound();
            }

            await _service.DeleteByIdAsync(id);

            return Ok();
        }
    }
}