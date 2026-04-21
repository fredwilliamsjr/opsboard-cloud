using Microsoft.EntityFrameworkCore;
using OpsBoard.Api.Data;
using OpsBoard.Api.DTOs;
using OpsBoard.Api.Entities;

namespace OpsBoard.Api.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly AppDbContext _context;
        public ServiceManager(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ServiceItem>> GetAllAsync()
        {
            return await _context.Services
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }
        public async Task<ServiceItem?> GetByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }
        public async Task<ServiceItem> CreateAsync(CreateServiceDto dto)
        {
            var service = new ServiceItem
            {
                Name = dto.Name,
                OwnerTeam = dto.OwnerTeam,
                Environment = dto.Environment,
                Status = dto.Status,
                CreatedAt = DateTime.UtcNow
            };
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return service;
        }
        public async Task<bool> UpdateAsync(int id, UpdateServiceDto dto)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
                return false;

            service.Name = dto.Name;
            service.OwnerTeam = dto.OwnerTeam;
            service.Environment = dto.Environment;
            service.Status = dto.Status;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
                return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
