using ProyectAntivirusBackend.Repositories;
using ProyectAntivirusBackend.Models;

public class RequestService : IRequestService
{
    private readonly IRequestRepository _repository;

    public RequestService(IRequestRepository repository)
    {
        _repository = repository;
    }

    // 🔹 Implementación correcta de GetAllAsync()
    public async Task<IEnumerable<RequestDto>> GetAllAsync()
    {
        var requests = await _repository.GetAllAsync();
        return requests.Select(r => new RequestDto
        {
            Id = r.Id,
            UserId = r.UserId,
            OpportunityId = r.OpportunityId,
            State = r.State,
            RequestDate = r.RequestDate
        });
    }

    // 🔹 Implementación correcta de GetByIdAsync()
    public async Task<RequestDto?> GetByIdAsync(int id)
    {
        var request = await _repository.GetByIdAsync(id);
        if (request == null)
        {
            return null;
        }
        return new RequestDto
        {
            Id = request.Id,
            UserId = request.UserId,
            OpportunityId = request.OpportunityId,
            State = request.State,
            RequestDate = request.RequestDate
        };
    }

    public async Task AddAsync(RequestDto dto)
    {
        var request = new Request
        {
            UserId = dto.UserId,
            OpportunityId = dto.OpportunityId,
            State = dto.State,
            RequestDate = dto.RequestDate
        };
        await _repository.AddAsync(request);
    }

    public async Task UpdateAsync(RequestDto dto)
    {
        var request = new Request
        {
            Id = dto.Id,
            UserId = dto.UserId,
            OpportunityId = dto.OpportunityId,
            State = dto.State,
            RequestDate = dto.RequestDate
        };
        await _repository.UpdateAsync(request);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
