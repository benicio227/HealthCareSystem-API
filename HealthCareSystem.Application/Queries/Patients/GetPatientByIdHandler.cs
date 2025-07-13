using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Patients
{
    public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, ApplicationResponse<GetByIdPatientResponse>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByIdHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<ApplicationResponse<GetByIdPatientResponse>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);

            if (patient is null)
            {
                return ApplicationResponse<GetByIdPatientResponse>.Fail("Paciente não encontrado.");
            }

            var response = new GetByIdPatientResponse
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                BloodType = patient.BloodType,
                Email = patient.Email,
                Height = patient.Height,
                Weight = patient.Weight,
                Cpf = patient.Cpf,
                Phone = patient.Phone,
                Address = patient.Address
            };

            return ApplicationResponse<GetByIdPatientResponse>.Ok(response);
        }
    }
}
