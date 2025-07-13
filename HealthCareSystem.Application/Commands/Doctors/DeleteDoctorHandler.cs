using HealthCareSystem.Application.Models;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Doctors
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, ApplicationResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDoctorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<Unit>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Doctors.GetById(request.Id);

            if (doctor == null)
            {
                return ApplicationResponse<Unit>.Fail("Médico não encontrado.");
            }

            await _unitOfWork.Doctors.Delete(doctor.Id);
            await _unitOfWork.CommitAsync();

            return ApplicationResponse<Unit>.Ok(Unit.Value);
        }
    }
}
