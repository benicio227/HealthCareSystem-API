using MediatR;

namespace HealthCareSystem.Application.DomainEvent
{
    public class AppointmentScheduledEvent : INotification
    {
        public AppointmentScheduledEvent(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }

        public Guid AppointmentId { get; }
    }
}
