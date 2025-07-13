using HealthCareSystem.Application.Models;
using HealthCareSystem.Application.Models.AppointmentResponse;
using MediatR;

namespace HealthCareSystem.Application.Queries.Appointments
{
    public class GetAllAppointmentQuery : IRequest<ApplicationResponse<List<GetAllAppointmentResponse>>>
    {

    }
}
