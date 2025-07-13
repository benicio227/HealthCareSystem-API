using HealthCareSystem.Core.Entities;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HealthCareSystemDbContext _context;
        public DoctorRepository(HealthCareSystemDbContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            return doctor;
        }
        public async Task<IReadOnlyList<Doctor>> GetAll()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }
        public async Task<Doctor?> GetById(Guid id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            return doctor;
        }
        public async Task Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }

        public async Task<bool> Delete(Guid id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor is null)
            {
                return false;
            }

            _context.Doctors.Remove(doctor);
            return true;
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            var doctor = await _context.Doctors.AnyAsync(d => d.Email == email);

            return doctor; //Usar AnyAsync quando quiser saber apenas sobre a existência do objeto, não carregar.
                           //É mais performático e rápido.
        }

        public async Task<Doctor?> GetByEmail(string email)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Email == email);
            return doctor;
        }
    }
}
