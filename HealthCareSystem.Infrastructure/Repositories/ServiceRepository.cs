using HealthCareSystem.Core.Entities;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly HealthCareSystemDbContext _context;
        public ServiceRepository(HealthCareSystemDbContext context)
        {
            _context = context;
        }
        public async Task<Service> Add(Service service)
        {
            _context.Services.Add(service);
            return service;
        }

        public async Task<IReadOnlyList<Service>> GetAll()
        {
            var services = await _context.Services.ToListAsync();
            return services;
        }
        public async Task<Service?> GetById(Guid id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            return service;
        }
        public async Task Update(Service service)
        {
            _context.Update(service);
        }
        public async Task<bool> Delete(Guid id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (service is null)
            {
                return false;
            }

            _context.Remove(service);
            return true;
        }
    }
}
