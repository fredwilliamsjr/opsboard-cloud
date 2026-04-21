using OpsBoard.Api.DTOs;
using OpsBoard.Api.Entities;

namespace OpsBoard.Api.Services
{
    public interface IServiceManager
    {
        Task<List<ServiceItem>> GetAllAsync();
        Task<ServiceItem?> GetByIdAsync(int id);
        Task<ServiceItem> CreateAsync(CreateServiceDto dto);
        Task<bool> UpdateAsync(int id, UpdateServiceDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
