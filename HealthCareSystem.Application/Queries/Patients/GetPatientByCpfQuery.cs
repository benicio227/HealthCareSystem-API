using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Patients
{
    public class GetPatientByCpfQuery : IRequest<ApplicationResponse<GetByCpfPatientResponse>>
    {
        public string Cpf {  get; set; } = string.Empty;
    }
}
