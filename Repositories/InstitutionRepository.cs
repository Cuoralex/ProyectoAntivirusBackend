using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.Models;

namespace ProyectAntivirusBackend.Repositories
{
    public interface IInstitutionRepository
    {
        Task<Institution?> GetByIdAsync(int id);
        Task<IEnumerable<Institution>> GetAllAsync();
        Task AddAsync(Institution institution);
        Task UpdateAsync(Institution institution);
        Task DeleteByIdAsync(int id);
    }
    
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly ApplicationDbContext _context;

        public InstitutionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Institution?> GetByIdAsync(int id)
        {
            return await _context.Institutions.FindAsync(id);
        }

        public async Task<IEnumerable<Institution>> GetAllAsync()
        {
            return await _context.Institutions.ToListAsync();
        }

        public async Task AddAsync(Institution institution)
        {
            await _context.Institutions.AddAsync(institution);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Institution institution)
        {
            _context.Institutions.Update(institution);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var institution = await _context.Institutions.FindAsync(id);

            if (institution != null)
            {
                _context.Institutions.Remove(institution);
                await _context.SaveChangesAsync();
            }
        }
    }
}