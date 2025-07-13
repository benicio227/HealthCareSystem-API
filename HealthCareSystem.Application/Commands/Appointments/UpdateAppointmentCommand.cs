using HealthCareSystem.Application.Models;
using HealthCareSystem.Core.Enums;
using MediatR;

namespace HealthCareSystem.Application.Commands.Appointments
{
    public class UpdateAppointmentCommand : IRequest<ApplicationResponse<Unit>>
    {   
        public Guid Id { get; private set; }
        public string Insurance { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentType Type { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
