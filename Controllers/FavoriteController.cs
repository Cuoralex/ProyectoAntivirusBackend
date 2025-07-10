using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.Models;
using ProyectAntivirusBackend.DTOs;

namespace ProyectAntivirusBackend.Controllers;

[ApiController]
[Route("api/v1/favorites")]
public class FavoriteController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public FavoriteController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Favorite>>> ObtenerFavoritos()
    {
        var favorites = await _context.Favorites.ToListAsync();
        return Ok(favorites);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Favorite>> ObtenerFavoritoPorId(int id)
    {
        var favorito = await _context.Favorites.FindAsync(id);
        if (favorito == null)
        {
            return NotFound("Favorito no encontrado.");
        }
        return Ok(favorito);
    }

    [HttpGet("{userId}/favorites")]
    public async Task<ActionResult<List<Opportunity>>> GetUserFavorites(int userId)
    {
        var favorites = await _context.Favorites
            .Where(f => f.UserId == userId)
            .Include(f => f.Opportunity)
            .Select(f => f.Opportunity)
            .ToListAsync();

        return Ok(favorites);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFavorite([FromBody] FavoriteDTO favoriteDto)
    {
        if (favoriteDto == null || favoriteDto.OpportunityId == 0 || favoriteDto.UserId == 0)
        {
            return BadRequest("Datos inválidos.");
        }

        var existingFavorite = await _context.Favorites
            .FirstOrDefaultAsync(f =>
                f.OpportunityId == favoriteDto.OpportunityId &&
                f.UserId == favoriteDto.UserId);

        if (existingFavorite != null)
        {
            return BadRequest("Esta oportunidad ya está marcada como favorita por este usuario.");
        }

        var favorite = new Favorite
        {
            UserId = favoriteDto.UserId,
            OpportunityId = favoriteDto.OpportunityId
        };

        _context.Favorites.Add(favorite);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(ObtenerFavoritoPorId), new { id = favorite.Id }, favorite);
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> CreateFavoriteWithId(int userId, [FromBody] FavoriteDTO favoriteDto)
    {
        if (favoriteDto == null || favoriteDto.OpportunityId == 0)
        {
            return BadRequest("Datos inválidos.");
        }

        var existingFavorite = await _context.Favorites
            .FirstOrDefaultAsync(f =>
                f.OpportunityId == favoriteDto.OpportunityId &&
                f.UserId == userId);

        if (existingFavorite != null)
        {
            return BadRequest("Esta oportunidad ya está marcada como favorita por este usuario.");
        }

        var favorite = new Favorite
        {
            UserId = userId,
            OpportunityId = favoriteDto.OpportunityId
        };

        _context.Favorites.Add(favorite);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(ObtenerFavoritoPorId), new { id = favorite.Id }, favorite);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarFavorito(int id, [FromBody] Favorite favorite)
    {
        if (id != favorite.Id)
        {
            return BadRequest("El ID del favorito no coincide.");
        }

        var favoritoExistente = await _context.Favorites.FindAsync(id);
        if (favoritoExistente == null)
        {
            return NotFound("Favorito no encontrado.");
        }

        _context.Entry(favoritoExistente).CurrentValues.SetValues(favorite);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Favorito actualizado correctamente.", data = favorite });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarFavorito(int id)
    {
        var favorito = await _context.Favorites.FindAsync(id);
        if (favorito == null)
        {
            return NotFound("Favorito no encontrado.");
        }

        _context.Favorites.Remove(favorito);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Favorito eliminado correctamente." });
    }
}

