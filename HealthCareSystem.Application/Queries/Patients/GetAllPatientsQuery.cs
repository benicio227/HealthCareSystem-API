using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.PatientResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Patients
{
    public class GetAllPatientsQuery : IRequest<ApplicationResponse<List<GetAllPatientsResponse>>>
    {

    }
}
