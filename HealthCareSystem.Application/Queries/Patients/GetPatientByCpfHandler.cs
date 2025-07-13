using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Patients
{
    public class GetPatientByCpfHandler : IRequestHandler<GetPatientByCpfQuery, ApplicationResponse<GetByCpfPatientResponse>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByCpfHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<ApplicationResponse<GetByCpfPatientResponse>> Handle(GetPatientByCpfQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByCpfAsync(request.Cpf);

            if (patient is null)
            {
                return ApplicationResponse<GetByCpfPatientResponse>.Fail("Paciente não encontrado.");
            }

            var response = new GetByCpfPatientResponse
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BloodType = patient.BloodType,
                DateOfBirth = patient.DateOfBirth,
                Cpf = patient.Cpf,
                Email = patient.Email,
                Phone = patient.Phone,
                Height = patient.Height,
                Weight = patient.Weight,
                Address = patient.Address
            };

            return ApplicationResponse<GetByCpfPatientResponse>.Ok(response);
        }
    }
}
