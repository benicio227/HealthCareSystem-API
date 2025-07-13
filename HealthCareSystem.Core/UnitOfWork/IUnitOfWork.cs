using HealthCareSystem.Core.Repositories;

namespace HealthCareSystem.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        IDoctorRepository Doctors { get; }
        IAppointmentRepository Appointmens { get; }
        IServiceRepository Services { get; }
        IDoctorTokenRepository Tokens { get; }

        Task<int> CommitAsync();
    }
}
