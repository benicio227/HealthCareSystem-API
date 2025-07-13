using HealthCareSystem.Core.Entities;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HealthCareSystemDbContext _context;
        public PatientRepository(HealthCareSystemDbContext context)
        {
            _context = context;
        }
        public async Task<Patient> AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            return patient;
        }
        public async Task<IReadOnlyList<Patient>> GetAllAsync()
        {
            var patients = await _context.Patients.ToListAsync();
            return patients;
        }
        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            return patient;
        }
        public async Task<Patient?> GetByCpfAsync(string cpf)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Cpf == cpf);
            return patient;
        }
        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (patient is null)
            {
                return false;
            }

            _context.Patients.Remove(patient);
 
            return true;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            var patient = await _context.Patients.AnyAsync(p => p.Email == email);
            return patient;
        }

        public async Task<Patient?> GetByPhoneAsync(string phone)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Phone == phone);
            return patient;
        }
    }
}
