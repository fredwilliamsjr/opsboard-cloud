using OpsBoard.Api.DTOs;
using OpsBoard.Api.Entities;

namespace OpsBoard.Api.Services
{
    public interface IIncidentManager
    {
        Task<List<Incident>> GetAllAsync();
        Task<Incident?> GetByIdAsync(int id);
        Task<Incident?> CreateAsync(CreateIncidentDto dto);
        Task<bool> UpdateAsync(int id, UpdateIncidentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}