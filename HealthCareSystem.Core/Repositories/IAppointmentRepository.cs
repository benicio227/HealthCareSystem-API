using HealthCareSystem.Core.Entities;

namespace HealthCareSystem.Core.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> Add(Appointment appointment);
        Task<IReadOnlyList<Appointment>> GetAll();
        Task<Appointment?> GetById(Guid id);
        Task Update(Appointment appointment);
        Task<bool> Delete(Guid id);
        Task<bool> ThereIsAScheduleConflict(Guid doctorId, DateTime newStart, DateTime newEnd);
    }
}
