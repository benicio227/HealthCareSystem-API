using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.AppointmentResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Appointments
{
    public class GetByIdAppointmentQuery : IRequest<ApplicationResponse<GetByIdAppointmentResponse>>
    {
        public Guid Id { get; set; }
    }
}
