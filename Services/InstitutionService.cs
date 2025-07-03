using ProyectAntivirusBackend.Models;
using ProyectAntivirusBackend.Repositories;

namespace ProyectAntivirusBackend.Service
{
    public interface IInstitutionService
    {
        Task<Institution?> GetByIdAsync(int id);
        Task<IEnumerable<Institution>> GetAllAsync();
        Task AddAsync(Institution institution);
        Task UpdateAsync(Institution institution);
        Task DeleteByIdAsync(int id);
    }

    public class InstitutionService : IInstitutionService
    {
        private readonly IInstitutionRepository _repository;

        public InstitutionService(IInstitutionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Institution?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Institution>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(Institution institution)
        {
            await _repository.AddAsync(institution);
        }

        public async Task UpdateAsync(Institution institution)
        {
            await _repository.UpdateAsync(institution);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}
