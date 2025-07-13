using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;

namespace HealthCareSystem.Application.Commands.Patients
{
    public class InsertPatientHandler : IRequestHandler<InsertPatientCommand, ApplicationResponse<InsertPatientResponse>>
    {
       private readonly IUnitOfWork _unitOfWork;

        public InsertPatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse<InsertPatientResponse>> Handle(InsertPatientCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Patients.ExistsByEmailAsync(request.Email))
            {
                return ApplicationResponse<InsertPatientResponse>.Fail("Já existe um paciente com esse e-mail.");
            }

            var patient = request.ToEntity();

            var exists = await _unitOfWork.Patients.GetByCpfAsync(request.Cpf);
            if (exists != null)
            {
                return ApplicationResponse<InsertPatientResponse>.Fail("Já existe um paciente com esse CPF.");
            }

            await _unitOfWork.Patients.AddAsync(patient);
            await _unitOfWork.CommitAsync();

            var response = new InsertPatientResponse
            {
                Id = patient.Id,
            };

            return ApplicationResponse<InsertPatientResponse>.Ok(response);
        }
    }
}
