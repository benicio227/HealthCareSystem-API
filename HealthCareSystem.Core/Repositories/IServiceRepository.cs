using HealthCareSystem.Core.Entities;

namespace HealthCareSystem.Core.Repositories
{
    public interface IServiceRepository
    {
        Task<Service> Add(Service service);
        Task<IReadOnlyList<Service>> GetAll();
        Task<Service?> GetById(Guid id);
        Task Update(Service service);
        Task<bool> Delete(Guid id);
    }
}
