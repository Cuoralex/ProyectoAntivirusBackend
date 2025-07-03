using ProyectAntivirusBackend.Models;
using ProyectAntivirusBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProyectAntivirusBackend.Services
{
 public class OpportunityTypeService
 {
 private readonly IOpportunityTypeRepository _repository;
 public OpportunityTypeService(IOpportunityTypeRepository repository)
 {
 _repository = repository;
 }
 public async Task<IEnumerable<OpportunityType>> GetAllAsync()
 {
 return await _repository.GetAllAsync();
 }
 public async Task<OpportunityType?> GetByIdAsync(int id)
 {
 return await _repository.GetByIdAsync(id);
 }
 public async Task AddAsync(OpportunityType opportunityType)
 {
 await _repository.AddAsync(opportunityType);
 }
 public async Task UpdateAsync(OpportunityType opportunityType)
 {
 await _repository.UpdateAsync(opportunityType);
 }
 public async Task DeleteAsync(int id)
 {
 await _repository.DeleteAsync(id);
 }
 }
}
