using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using HealthCareSystem.Infrastructure.Persistence;

namespace HealthCareSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthCareSystemDbContext _context;
        private readonly IPatientRepository _petientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorTokenRepository _doctorTokenRepository;
        private readonly IAppointmentRepository _AppointmentRepository;
        private readonly IServiceRepository _ServiceRepository;
        public UnitOfWork(HealthCareSystemDbContext context,
            IPatientRepository petientRepository,
            IDoctorRepository doctorRepository,
            IAppointmentRepository appointmentRepository,
            IServiceRepository serviceRepository,
            IDoctorTokenRepository doctorTokenRepository)
        {
            _context = context;
            _petientRepository = petientRepository;
            _doctorRepository = doctorRepository;
            _doctorTokenRepository = doctorTokenRepository;
            _AppointmentRepository = appointmentRepository;
            _ServiceRepository = serviceRepository;
        }
        public IPatientRepository Patients => _petientRepository;

        public IDoctorRepository Doctors => _doctorRepository;

        public IAppointmentRepository Appointmens => _AppointmentRepository;

        public IServiceRepository Services => _ServiceRepository;

        public IDoctorTokenRepository Tokens => _doctorTokenRepository;

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
