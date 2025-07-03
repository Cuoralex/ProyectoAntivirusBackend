using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.DTOs;
using ProyectAntivirusBackend.Models;
using ProfileModel = ProyectAntivirusBackend.Models.Profile;

namespace ProyectAntivirusBackend.Controllers
{
    [Route("api/v1/profile")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProfilesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/v1/profile
        // GET: api/v1/profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileDTO>>> GetProfiles()
        {
            var profiles = await _context.Profiles
                .Include(p => p.User)  // Incluir la relación con User
                .ToListAsync();

            var profileDTOs = profiles.Select(profile => new ProfileDTO
            {
                Id = profile.Id,
                UserId = profile.UserId,
                Preferences = profile.Preferences ?? "{}",
                Biography = profile.Biography ?? "",
                ProfilePicture = profile.ProfilePicture ?? "",
                Name = profile.User.FullName,
                Email = profile.User.Email,
                Phone = profile.User.Phone ?? ""
            });

            return Ok(profileDTOs);
        }


        // GET: api/v1/profile/5
        // GET: api/v1/profile/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileDTO>> GetProfile(int id)
        {
            var profile = await _context.Profiles
                .Include(p => p.User)  // Incluir la relación con User
                .FirstOrDefaultAsync(p => p.Id == id);

            if (profile == null) return NotFound();

            var profileDTO = new ProfileDTO
            {
                Id = profile.Id,
                UserId = profile.UserId,
                Preferences = profile.Preferences ?? "{}",
                Biography = profile.Biography ?? "",
                ProfilePicture = profile.ProfilePicture ?? "",
                Name = profile.User.FullName,
                Email = profile.User.Email,
                Phone = profile.User.Phone ?? ""
            };

            return Ok(profileDTO);
        }


        // POST: api/v1/profile
        // POST: api/v1/profile
        [HttpPost]
        public async Task<ActionResult<ProfileDTO>> PostProfile(CreateProfileDTO createProfileDTO)
        {
            var user = await _context.Users.FindAsync(createProfileDTO.UserId);
            if (user == null)
            {
                return BadRequest("El usuario no existe.");
            }

            var profile = new ProfileModel
            {
                UserId = user.Id,
                User = user,
                Preferences = createProfileDTO.Preferences,  // ← Usar el valor enviado
                Biography = createProfileDTO.Biography,  // ← Usar el valor enviado
                ProfilePicture = createProfileDTO.ProfilePicture // ← Usar el valor enviado
            };

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            var profileDTO = new ProfileDTO
            {
                Id = profile.Id,
                UserId = profile.UserId,
                Preferences = profile.Preferences,
                Biography = profile.Biography,
                ProfilePicture = profile.ProfilePicture,
                Name = profile.User.FullName,
                Email = profile.User.Email,
                Phone = profile.User?.Phone ?? string.Empty
            };

            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profileDTO);
        }

        // PUT: api/v1/profile/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, CreateProfileDTO createProfileDTO)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null) return NotFound();

            // Asignar los nuevos valores al perfil existente
            profile.Preferences = createProfileDTO.Preferences;
            profile.Biography = createProfileDTO.Biography;
            profile.ProfilePicture = createProfileDTO.ProfilePicture;

            _context.Entry(profile).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/v1/profile/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (profile == null) return NotFound();

            _context.Profiles.Remove(profile);

            if (profile.User != null)
            {
                _context.Users.Remove(profile.User);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}