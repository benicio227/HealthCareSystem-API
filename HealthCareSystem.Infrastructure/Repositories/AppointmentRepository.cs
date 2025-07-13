using HealthCareSystem.Core.Entities;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealthCareSystemDbContext _context;
        public AppointmentRepository(HealthCareSystemDbContext context)
        {
            _context = context;
        }
        public async Task<Appointment> Add(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            return appointment;
        }
        public async Task<IReadOnlyList<Appointment>> GetAll()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }
        public async Task<Appointment?> GetById(Guid id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.Id == id);
            return appointment;
        }

        public async Task Update(Appointment appointment)
        {
            _context.Update(appointment);
        }

        public async Task<bool> Delete(Guid id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
            if (appointment is null)
            {
                return false;
            }

            _context.Remove(appointment);
  
            return true;
        }

        public async Task<bool> ThereIsAScheduleConflict(Guid doctorId, DateTime newStart, DateTime newEnd)
        {
            return await _context.Appointments
                .AnyAsync(a =>
                    a.DoctorId == doctorId &&
                    newStart < a.EndTime &&
                    newEnd > a.StartTime
                );
        }
    }
}
