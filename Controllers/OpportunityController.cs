using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.DTOs;
using ProyectAntivirusBackend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectAntivirusBackend.Controllers
{

    [Route("api/v1/opportunity")]
    [ApiController]
    public class OpportunityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OpportunityController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // GET: api/v1/opportunity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpportunityDTO>>> GetOpportunity()
        {
            try
            {
                var opportunities = await _context.Opportunities
                    .Include(o => o.OpportunityTypes)
                        .ThenInclude(ot => ot.Categories)
                    .Include(o => o.Sectors)
                    .Include(o => o.Institutions)
                    .Include(o => o.Localities)
                    .ToListAsync();

                if (!opportunities.Any()) return NotFound();

                var opportunitiesDTO = _mapper.Map<List<OpportunityDTO>>(opportunities);

                return Ok(opportunitiesDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" ERROR EN GET OPPORTUNITY: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, "Ocurrió un error al obtener las oportunidades.");
            }
        }

        [HttpGet("opportunities.data")]
        public IActionResult GetOpportunities(string? title, int? opportunityTypeId, int? institutionId, int? localityId, DateTime? publicationDate, DateTime? expirationDate)
        {
            Console.WriteLine($"Filtros recibidos - Title: {title}, TypeId: {opportunityTypeId}, InstitutionId: {institutionId}, LocalityId: {localityId}, PublishedDate: {publicationDate}, ExpirationDate: {expirationDate}");

            var opportunities = _context.Opportunities.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                opportunities = opportunities.Where(o => o.Title.Contains(title));
            }

            // Filtro por tipo de oportunidad
            if (opportunityTypeId.HasValue)
            {
                opportunities = opportunities.Where(o => o.OpportunityTypeId == opportunityTypeId);
            }

            // Filtro por institución
            if (institutionId.HasValue)
            {
                opportunities = opportunities.Where(o => o.InstitutionId == institutionId);
            }

            // Filtro por ubicación (localidad)
            if (localityId.HasValue)
            {
                opportunities = opportunities.Where(o => o.LocalityId == localityId);
            }

            // Filtro por fecha de publicación
            if (publicationDate.HasValue)
            {
                opportunities = opportunities.Where(o => o.PublicationDate >= publicationDate);
            }

            // Filtro por fecha de expiración
            if (expirationDate.HasValue)
            {
                opportunities = opportunities.Where(o => o.ExpirationDate <= expirationDate);
            }

            var filteredOpportunities = opportunities.ToList();
            return Ok(filteredOpportunities);
        }

        // GET: api/v1/opportunity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OpportunityDTO>> GetOpportunity(int id)
        {
            var opportunity = await _context.Opportunities
                .Include(o => o.OpportunityTypes)
                    .ThenInclude(ot => ot.Categories)
                .Include(o => o.Sectors)
                .Include(o => o.Institutions)
                .Include(o => o.Localities)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (opportunity == null) return NotFound();

            var opportunityDTO = _mapper.Map<OpportunityDTO>(opportunity);
            return Ok(opportunityDTO);
        }

        // POST: api/v1/opportunity
        [HttpPost]
        public async Task<ActionResult<OpportunityDTO>> PostOpportunity([FromBody] CreateOpportunityDTO createOpportunityDTO)
        {
            Console.WriteLine($"📌 SectorId recibido: {createOpportunityDTO.SectorId}");
            Console.WriteLine($"📌 InstitutionId recibido: {createOpportunityDTO.InstitutionId}");
            Console.WriteLine($"📌 OpportunityTypeId recibido: {createOpportunityDTO.OpportunityTypeId}");
            Console.WriteLine($"📌 LocalityId recibido: {createOpportunityDTO.LocalityId}");

            // Validaciones de entidades relacionadas
            var sector = await _context.Sectors.FindAsync(createOpportunityDTO.SectorId);
            if (sector == null)
                return BadRequest("❌ Error: Sector inválido. Debe existir en la base de datos.");

            var institution = await _context.Institutions.FindAsync(createOpportunityDTO.InstitutionId);
            if (institution == null)
                return BadRequest("❌ Error: Institución inválida. Debe existir en la base de datos.");

            var opportunityType = await _context.OpportunityTypes.FindAsync(createOpportunityDTO.OpportunityTypeId);
            if (opportunityType == null)
                return BadRequest("❌ Error: Tipo de oportunidad inválido.");

            var locality = await _context.Localities.FindAsync(createOpportunityDTO.LocalityId);
            if (locality == null)
                return BadRequest("❌ Error: Tipo de oportunidad inválido.");

            // Creación del objeto Opportunity
            var opportunity = new Opportunity
            {
                Title = createOpportunityDTO.Title,
                Description = createOpportunityDTO.Description,
                SectorId = createOpportunityDTO.SectorId,
                InstitutionId = createOpportunityDTO.InstitutionId,
                OpportunityTypeId = createOpportunityDTO.OpportunityTypeId,
                LocalityId = createOpportunityDTO.LocalityId,
                Requirements = createOpportunityDTO.Requirements,
                Benefits = createOpportunityDTO.Benefits,
                Modality = createOpportunityDTO.Modality,
                PublicationDate = DateTime.UtcNow,
                ExpirationDate = createOpportunityDTO.ExpirationDate,
                Status = createOpportunityDTO.Status,
                Sectors = sector,
                Institutions = institution,
                OpportunityTypes = opportunityType,
                Localities = locality,
                Ratings = new List<Rating>()
,
            };


            _context.Opportunities.Add(opportunity);
            await _context.SaveChangesAsync();

            var opportunityDTO = _mapper.Map<OpportunityDTO>(opportunity);

            return CreatedAtAction(nameof(GetOpportunity), new { id = opportunity.Id }, opportunityDTO);
        }

        // GET: api/v1/rating
        [HttpGet("{id}/rating/{userId}")]
        public async Task<IActionResult> GetRating(int id, int userId)
        {
            var rating = await _context.Ratings
                .Where(r => r.OpportunityId == id)
                .ToListAsync();

            var userRating = rating.FirstOrDefault(r => r.UserId == userId);
            var averageRating = rating.Any() ? rating.Average(r => r.Score) : 0;

            return Ok(new
            {
                Average = averageRating,
                UserRating = userRating?.Score
            });
        }

        // POST: api/v1/rating
        [HttpPost("{id}/rate/{userId}")]
        public async Task<IActionResult> RateOpportunity(int id, int userId, [FromBody] RatingRequest request)
        {

            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null) return NotFound("Oportunidad no encontrada.");

            if (request.Score < 1 || request.Score > 5)
            {
                return BadRequest("La calificación debe estar entre 1 y 5.");
            }
            var existingRating = await _context.Ratings
                .FirstOrDefaultAsync(r => r.UserId == userId && r.OpportunityId == id);

            if (existingRating != null)
            {
                // Si ya votó, actualizar su puntuación y comentario
                existingRating.Score = (int)request.Score;
                existingRating.Comment = (string)request.Comment;
            }
            else
            {
                // Si no ha votado, registrar la calificación
                var rating = new Rating
                {
                    UserId = userId,
                    OpportunityId = id,
                    Score = (int)request.Score,
                    Comment = (string)request.Comment,

                };
                _context.Ratings.Add(rating);
            }


            await _context.SaveChangesAsync();

            // Recalcular promedio de calificaciones y total de votos
            var ratings = await _context.Ratings
                .Where(r => r.OpportunityId == id)
                .ToListAsync();

            var averageRating = ratings.Average(r => r.Score);
            var totalVotes = ratings.Count;

            return Ok(new { newRating = averageRating, totalVotes });
        }

        private int GetUserIdFromToken()
        {
            var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;
            if (identity != null)
            {
                var userIdClaim = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    return int.Parse(userIdClaim.Value);
                }
            }
            return 0; // Usuario no autenticado
        }


        // PUT: api/v1/opportunity/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpportunity(int id, [FromBody] CreateOpportunityDTO createOpportunityDTO)
        {
            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null) return NotFound();

            _mapper.Map(createOpportunityDTO, opportunity);
            _context.Entry(opportunity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/v1/opportunity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpportunity(int id)
        {
            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null) return NotFound();

            _context.Opportunities.Remove(opportunity);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }

    public class RatingRequest
    {
        public int Score { get; set; }
        public required string Comment { get; set; }
    }

}
