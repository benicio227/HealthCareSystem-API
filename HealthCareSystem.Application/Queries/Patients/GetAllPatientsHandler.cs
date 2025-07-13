using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Queries.Patients
{
    public class GetAllPatientsHandler : IRequestHandler<GetAllPatientsQuery, ApplicationResponse<List<GetAllPatientsResponse>>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllPatientsHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<ApplicationResponse<List<GetAllPatientsResponse>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync();

            var response = patients.Select(p => new GetAllPatientsResponse
            {
                Id = p.Id,
                FullName = $"{p.FirstName} {p.LastName}",
                Email = p.Email,
                Phone = p.Phone,
                Cpf = p.Cpf
            }).ToList();

            return ApplicationResponse<List<GetAllPatientsResponse>>.Ok(response);
        }
    }
}
