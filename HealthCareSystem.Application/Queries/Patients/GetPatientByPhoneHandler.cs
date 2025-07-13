using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Patients
{
    public class GetPatientByPhoneHandler : IRequestHandler<GetPatientByPhoneQuery, ApplicationResponse<GetByPhonePatientResponse>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByPhoneHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<ApplicationResponse<GetByPhonePatientResponse>> Handle(GetPatientByPhoneQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByPhoneAsync(request.Phone);

            if (patient is null)
            {
                return ApplicationResponse<GetByPhonePatientResponse>.Fail("Paciente não encontrado.");
            }

            var response = new GetByPhonePatientResponse
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                Address = patient.Address,
                BloodType = patient.BloodType,
                Cpf = patient.Cpf,
                DateOfBirth = patient.DateOfBirth,
                Height = patient.Height,
                Weight = patient.Weight,
                Phone = patient.Phone
            };

            return ApplicationResponse<GetByPhonePatientResponse>.Ok(response);
        }
    }
}
