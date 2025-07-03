using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectAntivirusBackend.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Request>> GetAllAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request?> GetByIdAsync(int id)
        {
            return await _context.Requests.FindAsync(id);
        }

        public async Task<Request> AddAsync(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<Request?> UpdateAsync(Request request)
        {
            var existingRequest = await _context.Requests.FindAsync(request.Id);
            if (existingRequest == null)
                return null;

            _context.Entry(existingRequest).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
            return existingRequest;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
                return false;

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
