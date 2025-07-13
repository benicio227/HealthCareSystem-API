using HealthCareSystem.Application.Models;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Patients
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, ApplicationResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<Unit>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.Id);

            if (patient is null)
            {
                return ApplicationResponse<Unit>.Fail("Paciente não encontrado");
            }

            await _unitOfWork.Patients.DeleteAsync(patient.Id);
            await _unitOfWork.CommitAsync();

            return ApplicationResponse<Unit>.Ok(Unit.Value);
        }
    }
}
