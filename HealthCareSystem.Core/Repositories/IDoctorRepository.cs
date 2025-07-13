using HealthCareSystem.Core.Entities;

namespace HealthCareSystem.Core.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> Add(Doctor doctor);
        Task<IReadOnlyList<Doctor>> GetAll();
        Task<Doctor?> GetById(Guid id);
        Task<Doctor?> GetByEmail(string email);
        Task Update(Doctor doctor);
        Task<bool> Delete(Guid id);
        Task<bool> ExistsByEmail(string email);
    }
}
