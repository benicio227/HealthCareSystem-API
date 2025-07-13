using HealthCareSystem.Core.Entities;

namespace HealthCareSystem.Core.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> AddAsync(Patient patient);
        Task<IReadOnlyList<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(Guid id);
        Task<Patient?> GetByCpfAsync(string cpf);
        Task<Patient?> GetByPhoneAsync(string phone);
        Task UpdateAsync(Patient patient);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
