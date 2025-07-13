using HealthCareSystem.Application.DomainEvent;
using HealthCareSystem.Core.Repositories;
using MediatR;

namespace HealthCareSystem.Application.Events
{
    public class AppointmentSheduledHandler : INotificationHandler<AppointmentScheduledEvent>
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentSheduledHandler(
            IEmailService emailService,
            ISmsService smsService,
            IAppointmentRepository appointmentRepository)
        {
            _emailService = emailService;
            _smsService = smsService;
            _appointmentRepository = appointmentRepository;
        }
        public async Task Handle(AppointmentScheduledEvent notification, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetById(notification.AppointmentId);

            if (appointment is null)
            {
                return;
            }

            var patient = appointment.Patient;

            var message = $"Olá {patient.FirstName}, seu agendamento foi confirmado para {appointment.StartTime:dd/MM/yyyy HH:MM}.";

           await _smsService.SendSms(patient.Phone, message);
        }
    }
}
