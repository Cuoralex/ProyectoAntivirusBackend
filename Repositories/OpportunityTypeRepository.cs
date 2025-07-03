using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Models;
using ProyectAntivirusBackend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProyectAntivirusBackend.Repositories
{
 public class OpportunityTypeRepository : IOpportunityTypeRepository
 {
 private readonly ApplicationDbContext _context;
 public OpportunityTypeRepository(ApplicationDbContext context)
 {
 _context = context;
 }
 public async Task<IEnumerable<OpportunityType>> GetAllAsync()
 {
 return await _context.OpportunityTypes.ToListAsync();
 }
 public async Task<OpportunityType?> GetByIdAsync(int id)
 {
 return await _context.OpportunityTypes.FindAsync(id);
 }
 public async Task AddAsync(OpportunityType opportunityType)
 {
 await _context.OpportunityTypes.AddAsync(opportunityType);
 await _context.SaveChangesAsync();
 }
 public async Task UpdateAsync(OpportunityType opportunityType)
 {
 _context.OpportunityTypes.Update(opportunityType);
 await _context.SaveChangesAsync();
 }
 public async Task DeleteAsync(int id)
 {
 var entity = await _context.OpportunityTypes.FindAsync(id);
 if (entity != null)
 {
 _context.OpportunityTypes.Remove(entity);
 await _context.SaveChangesAsync();
 }
 }
 }

    public interface IOpportunityTypeRepository
    {
        Task AddAsync(OpportunityType opportunityType);
        Task DeleteAsync(int id);
        Task<IEnumerable<OpportunityType>> GetAllAsync();
        Task<OpportunityType?> GetByIdAsync(int id);
        Task UpdateAsync(OpportunityType opportunityType);
    }
}
