using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.DoctorResponse;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Doctors
{
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorCommand, ApplicationResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDoctorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<Unit>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Doctors.GetById(request.Id);

            if (doctor is null)
            {
                return ApplicationResponse<Unit>.Fail("Médico não encontrado.");
            }

            doctor.UpdateDoctor(request.FirstName, request.LastName, request.Phone, request.Email, request.Address, request.Specialty);

            await _unitOfWork.Doctors.Update(doctor);
            await _unitOfWork.CommitAsync();

            return ApplicationResponse<Unit>.Ok(Unit.Value);
        }
    }
}
