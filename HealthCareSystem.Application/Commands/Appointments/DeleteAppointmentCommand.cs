using HealthCareSystem.Application.Models;
using MediatR;

namespace HealthCareSystem.Application.Commands.Appointments
{
    public class DeleteAppointmentCommand : IRequest<ApplicationResponse<Unit>>
    {
        public Guid Id { get; set; }
    }
}
