using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectAntivirusBackend.Services;
using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.DTOs; // Asegúrate de que este using esté presente
using ProyectAntivirusBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProyectAntivirusBackend.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public UsersController(ApplicationDbContext context, IMapper mapper, JwtService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService; // Inyectar JwtService
        }

        // POST: api/v1/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDTO.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PasswordHash))
                return Unauthorized(new { message = "Credenciales inválidas" });

            var token = _jwtService.GenerateToken(user.Email, user.Role);

            Response.Cookies.Append("authToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            return Ok(new
            {
                email = user.Email,
                role = user.Role,
                token = token
            });
        }

        // GET: api/v1/user
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(userDTOs);
        }

        // GET: api/v1/user/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        // POST: api/v1/user
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(CreateUserDTO createUserDTO)
        {
            var existingUser = await _context.Users
                .AnyAsync(u => u.Email == createUserDTO.Email);

            if (existingUser)
            {
                return Conflict(new { userExists = "El correo ya está registrado." });
            }

            if (createUserDTO.Birthdate == default || createUserDTO.Birthdate > DateTime.UtcNow)
            {
                return BadRequest(new { error = "Fecha de nacimiento inválida." });
            }

            var user = _mapper.Map<User>(createUserDTO);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDTO.Password);
            user.RegistrationDate = DateTime.UtcNow;
            user.IsActive = true;
            user.Birthdate = createUserDTO.Birthdate;

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("IX_users_Email") == true)
                {
                    return Conflict(new { userExists = "El correo ya está registrado." });
                }

                throw;
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, userDTO);
        }


        // PUT: api/v1/user/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, CreateUserDTO createUserDTO)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _mapper.Map(createUserDTO, user);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(int id, [FromBody] UpdateUserDTO dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _mapper.Map(dto, user);

            user.Birthdate = DateTime.SpecifyKind(user.Birthdate, DateTimeKind.Utc);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateUserStatusDTO dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.IsActive = dto.IsActive;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/v1/user/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}