using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.DoctorResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Doctors
{
    public class GetAllDoctorQuery : IRequest<ApplicationResponse<List<GetAllDoctorResponse>>>
    {

    }
}
