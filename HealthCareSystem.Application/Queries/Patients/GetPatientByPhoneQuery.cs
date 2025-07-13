using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Patients
{
    public class GetPatientByPhoneQuery : IRequest<ApplicationResponse<GetByPhonePatientResponse>>
    {
        public string Phone { get; set; } = string.Empty;
    }
}
