using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Patients
{
    public class GetPatientByIdQuery : IRequest<ApplicationResponse<GetByIdPatientResponse>>
    {
        public Guid Id {  get; set; }
    }
}
