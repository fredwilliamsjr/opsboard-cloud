using Microsoft.EntityFrameworkCore;
using OpsBoard.Api.Data;
using OpsBoard.Api.DTOs;
using OpsBoard.Api.Entities;

namespace OpsBoard.Api.Services
{
    public class IncidentManager : IIncidentManager
    {
        private readonly AppDbContext _context;

        public IncidentManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Incident>> GetAllAsync()
        {
            return await _context.Incidents
                .Include(i => i.ServiceItem)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }

        public async Task<Incident?> GetByIdAsync(int id)
        {
            return await _context.Incidents
                .Include(i => i.ServiceItem)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Incident?> CreateAsync(CreateIncidentDto dto)
        {
            var serviceExists = await _context.Services.AnyAsync(s => s.Id == dto.ServiceItemId);

            if (!serviceExists)
                return null;

            var incident = new Incident
            {
                Title = dto.Title,
                Severity = dto.Severity,
                Status = dto.Status,
                Description = dto.Description,
                ServiceItemId = dto.ServiceItemId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();

            return incident;
        }

        public async Task<bool> UpdateAsync(int id, UpdateIncidentDto dto)
        {
            var incident = await _context.Incidents.FindAsync(id);

            if (incident == null)
                return false;

            var serviceExists = await _context.Services.AnyAsync(s => s.Id == dto.ServiceItemId);

            if (!serviceExists)
                return false;

            incident.Title = dto.Title;
            incident.Severity = dto.Severity;
            incident.Status = dto.Status;
            incident.Description = dto.Description;
            incident.ServiceItemId = dto.ServiceItemId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);

            if (incident == null)
                return false;

            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}