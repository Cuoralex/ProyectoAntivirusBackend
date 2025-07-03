using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.Models;

namespace ProyectAntivirusBackend.Controllers
{
    [ApiController]
    [Route("api/v1/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rating>>> GetAllRatings()
        {
            try
            {
                var ratings = await _context.Ratings.ToListAsync();
                if (ratings == null || ratings.Count == 0)
                {
                    return NotFound(new { message = "No hay calificaciones registradas" });
                }
                return Ok(ratings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Rating>>> GetUserRatings(int userId)
        {
            var ratings = await _context.Ratings
                .Where(r => r.UserId == userId)
                .Include(r => r.Opportunity)
                .ToListAsync();

            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRatingById(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound(new { message = "Calificación no encontrada" });
            }
            return Ok(rating);
        }

        [HttpGet("opportunity/{opportunityId}/average")]
        public async Task<ActionResult<double>> GetAverageRating(int opportunityId)
        {
            var average = await _context.Ratings
                .Where(r => r.OpportunityId == opportunityId)
                .AverageAsync(r => (double?)r.Score) ?? 0;

            return Ok(new { average });
        }

        [HttpPost("opportunity/{opportunityId}/average")]
        public async Task<ActionResult<double>> AddRatingAndCalculateAverage(
    [FromRoute] int opportunityId, [FromBody] Rating request)
        {
            if (request.Score < 1 || request.Score > 5)
            {
                return BadRequest(new { message = "El puntaje debe estar entre 1 y 5." });
            }

            var opportunity = await _context.Opportunities.FindAsync(opportunityId);
            if (opportunity == null)
            {
                return NotFound(new { message = "Oportunidad no encontrada" });
            }

            _context.Ratings.Add(request);
            await _context.SaveChangesAsync();

            // Recalcular el promedio
            double newAverage = await _context.Ratings
                .Where(r => r.OpportunityId == opportunityId)
                .AverageAsync(r => r.Score);

            // Guardar el promedio en la oportunidad
            opportunity.AverageScore = newAverage;
            await _context.SaveChangesAsync();

            return Ok(new { average = newAverage });
        }

        [HttpPost]
        public async Task<IActionResult> CreateRating([FromBody] Rating request)
        {
            Console.WriteLine("📥 Se recibió una petición POST en /ratings");
            Console.WriteLine($"➡️ OpportunityId: {request.OpportunityId}, UserId: {request.UserId}, Score: {request.Score}, Comment: {request.Comment}");

            if (request.UserId <= 0 || request.OpportunityId <= 0 || request.Score < 1 || request.Score > 5)
            {
                return BadRequest(new { message = "Datos inválidos: asegúrate de incluir UserId, OpportunityId y un Score entre 1 y 5." });
            }

            Console.WriteLine("⚠️ Datos inválidos en la petición");
            var exists = await _context.Ratings
                .AnyAsync(r => r.OpportunityId == request.OpportunityId && r.UserId == request.UserId);

            if (exists)
            {
                Console.WriteLine("⚠️ El usuario ya votó por esta oportunidad");
                return Conflict(new { message = "Ya existe una calificación de este usuario para esta oportunidad." });
            }

            var opportunity = await _context.Opportunities.FindAsync(request.OpportunityId);
            if (opportunity == null)
            {
                Console.WriteLine("❌ Oportunidad no encontrada");
                return NotFound(new { message = "Oportunidad no encontrada" });
            }

            _context.Ratings.Add(request);
            await _context.SaveChangesAsync();

            Console.WriteLine("✅ Calificación guardada correctamente");
            return CreatedAtAction(nameof(GetUserRatings), new { userId = request.UserId }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] Rating updatedRating)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound(new { message = "Calificación no encontrada" });
            }

            if (updatedRating.Score < 1 || updatedRating.Score > 5)
            {
                return BadRequest(new { message = "El puntaje debe estar entre 1 y 5" });
            }

            rating.Score = updatedRating.Score;
            rating.Comment = updatedRating.Comment;
            await _context.SaveChangesAsync();

            return Ok(rating);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound(new { message = "Calificación no encontrada" });
            }

            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
