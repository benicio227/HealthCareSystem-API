using HealthCareSystem.Core.Repositories;

namespace HealthCareSystem.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public Task SendConfirmation(Guid appointmentId)
        {
            Console.WriteLine($"[Email enviado] Confirmação de agendamento ID: {appointmentId}");
            return Task.CompletedTask;
        }
    }
}
