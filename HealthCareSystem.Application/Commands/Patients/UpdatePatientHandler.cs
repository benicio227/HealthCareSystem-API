using HealthCareSystem.Application.Models;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Patients
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, ApplicationResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<Unit>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.Id);

            if (patient is null)
            {
                return ApplicationResponse<Unit>.Fail("Paciente não encontrado.");
            }

            patient.UpdatePatient(
                request.FirstName,
                request.LastName,
                request.Phone,
                request.Email,
                request.Height,
                request.Weight,
                request.Address
            );

            await _unitOfWork.Patients.UpdateAsync(patient);
            await _unitOfWork.CommitAsync();

            return ApplicationResponse<Unit>.Ok(Unit.Value);
        }
    }
}
