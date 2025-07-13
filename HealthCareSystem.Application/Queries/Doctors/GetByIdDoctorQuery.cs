using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.DoctorResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Doctors
{
    public class GetByIdDoctorQuery : IRequest<ApplicationResponse<GetByIdDoctorResponse>>
    {
        public Guid Id { get; set; }
    }
}
